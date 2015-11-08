using UnityEngine;
using System.Collections;
using System;

public class SetAnimatorBoolWhenTargetYLowerThan : MonoBehaviour
{
    public Transform Target;
    private Animator Animator;
    public float YValue = 0f;
    public string ParameterName;

    void Start()
    {
        if (Target == null)
            throw new NullReferenceException("Target can not be null!");
        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new NullReferenceException("Animator can not be null!");
        if (ParameterName == null)
            throw new NullReferenceException("ParameterName can not be null!");
    }

    void Update()
    {
        if (Target.transform.position.y < YValue)
            Animator.SetBool(ParameterName, true);
    }
}
