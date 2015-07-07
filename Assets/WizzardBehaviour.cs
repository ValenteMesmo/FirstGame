using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2DHandler))]
[RequireComponent(typeof(AnimatorHandler))]
public class WizzardBehaviour : MonoBehaviour
{
    CircleCollider2DHandler Collider;
    AnimatorHandler animator;
    public Transform[] positions;
    private int currentPosition = 0;

    ScoreDisplayBehaviour Score;
    IVibration Vibration;

    protected override void OnAwake()
    {
        base.OnAwake();
        Collider = GetComponent<CircleCollider2DHandler>();
        animator = GetComponent<AnimatorHandler>();

        Score = GlobalComponents.Get<ScoreDisplayBehaviour>();

        Collider.OnCollisionEnter += onhit;
        Vibration = new VibrationHandler(this);
    }

    public void EnableCollisions()
    {
        Collider.EnableCollider2D();
    }

    public void DisableCollisions()
    {
        Collider.DisableCollider2D();
    }

    void onhit(object sender, Collision2DEventArgs e)
    {
        if (e.Tag == "Player")
        {
            animator.SetBool("dead", true);

            Score.Score += 100;
            Vibration.Vibrate(200);

            DelayExecution(ReappearOnNextPosition, 1f);
        }
    }

    private void ReappearOnNextPosition()
    {
        currentPosition++;

        if (currentPosition > positions.Length - 1)
            currentPosition = 0;

        transform.position = positions[currentPosition].position;

        animator.SetBool("dead", false);
    }
}
