using UnityEngine;
using System.Collections;
using System;

public class PlayAnimationOnTriggerEnter : MonoBehaviour
{
    public Animator Animator;

    public string AnimationName;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            if (Animator != null)
                Animator.Play(AnimationName);
        }
    }
}
