using UnityEngine;
using System.Collections;

public class FireflyTimeAfterNHits : MonoBehaviour
{
    Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            GlobalComponents.HideFireflyWave = false;
            Animator.SetBool("dead", true);
            DelayExecution(() =>
            {
                GlobalComponents.HideFireflyWave = true;
                Animator.SetBool("dead", false);

            }, 360f);
        }
    }
}
