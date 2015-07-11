using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class SetAnimatorBooleanOnChildTriggers : MonoBehaviour
{
    public string ParameterName;

    Animator Animator;

    private int numberOfObjectsOnTrigger = 0;

    void Start()
    {
        if (string.IsNullOrEmpty(ParameterName))
            throw new Exception("ParameterName can not be empty!");

        Animator = GetComponent<Animator>();

        foreach (var trigger in GetComponentsInChildren<TriggerEvents>())
        {
            trigger.Enter += trigger_Enter;
            trigger.Exit += trigger_Exit;
        }
    }

    void trigger_Exit(object sender, TriggerEventArgs e)
    {
        if (e.Collider.tag == "Player")
        {
            numberOfObjectsOnTrigger--;
            Animator.SetBool(ParameterName, numberOfObjectsOnTrigger > 0);
        }
    }

    void trigger_Enter(object sender, TriggerEventArgs e)
    {
        if (e.Collider.tag == "Player")
        {
            numberOfObjectsOnTrigger++;
            Animator.SetBool(ParameterName, numberOfObjectsOnTrigger > 0);
        }
    }
}
