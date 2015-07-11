using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class SetAnimatorBooleanOnChildTriggers : MonoBehaviour
{
    public string ParameterName;

    Animator Animator;

    void Start()
    {
        if (string.IsNullOrEmpty(ParameterName))
            throw new Exception("ParameterName can not be empty!");

        Animator = GetComponent<Animator>();

        foreach (var trigger in GetComponentsInChildren<TriggerEvents>())
        {
            trigger.Enter += trigger_Enter;
            trigger.Exit += trigger_Exit;
            trigger.Stay += trigger_Stay;
        }
    }

    void trigger_Stay(object sender, TriggerEventArgs e)
    {
        if (e.Collider.tag == "Player")
        {
            Animator.SetBool(ParameterName, true);
        }
    }

    void trigger_Exit(object sender, TriggerEventArgs e)
    {
        if (e.Collider.tag == "Player")
        {
            Animator.SetBool(ParameterName, false);
        }
    }

    void trigger_Enter(object sender, TriggerEventArgs e)
    {
        if (e.Collider.tag == "Player")
        {
            Animator.SetBool(ParameterName, true);
        }
    }
}
