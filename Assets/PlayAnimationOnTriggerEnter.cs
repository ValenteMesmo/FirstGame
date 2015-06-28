using UnityEngine;
using System.Collections;

public class PlayAnimationOnTriggerEnter : MonoBehaviour
{
    public Animator Animator;

    public string AnimationName;
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            Animator.Play(AnimationName);
        }
    }
}
