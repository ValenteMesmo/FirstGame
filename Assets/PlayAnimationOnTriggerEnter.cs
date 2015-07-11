using UnityEngine;
using System.Collections;
using System;

//TODO: rename 
public class PlayAnimationOnTriggerEnter : MonoBehaviour
{
    public Animator Animator;

    public string ParameterName;
    public bool Value;

    void Start()
    {
        Animator = Animator.gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            if (Animator != null)
                Animator.SetBool(ParameterName, Value);
        }
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            if (Animator != null)
                Animator.SetBool(ParameterName, !Value);
        }
    }
}
