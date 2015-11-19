using UnityEngine;
using System.Collections;
using System;

public class SetAnimatorBoolOnTriggerEnter : MonoBehaviour
{
    public string ParameterName;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new NullReferenceException("Animator");
        if (ParameterName == null)
            throw new NullReferenceException("ParameterName");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            Animator.SetBool(ParameterName, true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            Animator.SetBool(ParameterName, false);
    }
}
