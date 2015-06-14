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
        Vibration = new VibrationHandler();
    }

    void onhit(object sender, Collision2DEventArgs e)
    {
        if (e.Tag == "Player")
        {
            animator.SetBool("dead", true);
            Collider.DisableCollider2D();

            Score.Score += 1000;
            Vibration.Vibrate(200);

            DelayExecution(() =>
            {
                transform.position = positions[currentPosition].position;
                currentPosition++;
                if (currentPosition > positions.Length - 1)
                    currentPosition = 0;
                animator.SetBool("dead", false);
                Collider.EnableCollider2D();
            }, 10); 
        }
    }
}
