using UnityEngine;
using System.Collections;

public class TriggerAnimationOnCollision : MonoBehaviour
{
    Animator Animator;
    public string triggerName;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            Animator.SetTrigger(triggerName);
        }
    }
}
