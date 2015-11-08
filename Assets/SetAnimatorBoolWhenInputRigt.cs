using UnityEngine;
using System.Collections;
using System;

public class SetAnimatorBoolWhenInputRigt : MonoBehaviour
{
    Animator Animator;
    public ControlsPlayerInputs ControlsPlayerInputs;
    public string ParameterName;
    public bool ParameterValue = true;

    void Start()
    {
        if (ControlsPlayerInputs == null)
            throw new NullReferenceException("ControlsPlayerInputs");

        ControlsPlayerInputs.RightButtonDown += ControlsPlayerInputs_RightButtonDown;
        ControlsPlayerInputs.RightButtonUp += ControlsPlayerInputs_RightButtonUp;

        if (ParameterName == null)
            throw new NullReferenceException("ParameterName");

        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new NullReferenceException("Animator cannot be null!");        
    }

    void ControlsPlayerInputs_RightButtonUp(object sender, EventArgs e)
    {
        Animator.SetBool(ParameterName, ParameterValue);
    }

    void ControlsPlayerInputs_RightButtonDown(object sender, EventArgs e)
    {
        Animator.SetBool(ParameterName, !ParameterValue);
    }
}
