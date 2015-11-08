using UnityEngine;
using System.Collections;
using System;

public class SetAnimatorBoolWhenInputLeft : MonoBehaviour {

    Animator Animator;
    public ControlsPlayerInputs ControlsPlayerInputs;
    public string ParameterName;
    public bool ParameterValue = true;

    void Start()
    {
        if (ControlsPlayerInputs == null)
            throw new NullReferenceException("ControlsPlayerInputs");

        ControlsPlayerInputs.LeftButtonDown += ControlsPlayerInputs_LeftButtonDown;
        ControlsPlayerInputs.LeftButtonUp += ControlsPlayerInputs_LeftButtonUp;

        if (ParameterName == null)
            throw new NullReferenceException("ParameterName");

        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new NullReferenceException("Animator cannot be null!");
    }

    void ControlsPlayerInputs_LeftButtonUp(object sender, EventArgs e)
    {
        Animator.SetBool(ParameterName, ParameterValue);
    }

    void ControlsPlayerInputs_LeftButtonDown(object sender, EventArgs e)
    {
        Animator.SetBool(ParameterName, !ParameterValue);
    }
}
