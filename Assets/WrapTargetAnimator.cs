using UnityEngine;
using System.Collections;
using System;

public class WrapTargetAnimator : MonoBehaviour
{
    public Animator Target;

    void Start()
    {
        if (Target == null)
            throw new Exception("The Target Animator was not set. It is required.");
    }

    public void SetTrueOnTargetAnimatorBoolean(string parameterName)
    {
        Target.SetBool(parameterName, true);
    }

    public void SetFalseOnTargetAnimatorBoolean(string parameterName)
    {
        Target.SetBool(parameterName, false);
    }
}
