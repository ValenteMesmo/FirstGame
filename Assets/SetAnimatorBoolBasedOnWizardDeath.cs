using UnityEngine;
using System.Collections;
using System;

public class SetAnimatorBoolBasedOnWizardDeath : MonoBehaviour
{

    Animator Animator;

    public string ParameterName;

    void Start()
    {
        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new NullReferenceException("Animator");
        if (ParameterName == null)
            throw new NullReferenceException("ParameterName");
    }

    void Update()
    {
        Animator.SetBool(ParameterName, GlobalComponents.WizardIsDead);

    }
}
