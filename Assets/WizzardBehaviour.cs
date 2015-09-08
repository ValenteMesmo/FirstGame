using UnityEngine;
using System.Collections;

public class WizzardBehaviour : MonoBehaviour
{
    Animator animator;
    public Transform[] positions;
    private int currentPosition = 0;

    ScoreDisplayBehaviour Score;
    IVibration Vibration;

    protected void Awake()
    {
        animator = GetComponent<Animator>();

        Score = GlobalComponents.Get<ScoreDisplayBehaviour>();

        Vibration = new VibrationHandler(this);
    }

    //public void EnableCollisions()
    //{
    //    Collider.EnableCollider2D();
    //}

    //public void DisableCollisions()
    //{
    //    Collider.DisableCollider2D();
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("dead", true);

            Score.AddScore(100);
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
