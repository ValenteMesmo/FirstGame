using UnityEngine;
using System.Collections;

public class PlayAnimationOnTriggerStay : MonoBehaviour
{
    public Animator Animator;

    public string AnimationName;
    
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            Animator.Play(AnimationName);
        }
    }
}
