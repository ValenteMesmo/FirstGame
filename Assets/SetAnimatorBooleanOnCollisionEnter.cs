using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SetAnimatorBooleanOnCollisionEnter : MonoBehaviour
{
    Animator Animator;
    public string ParameterName = "";
    public bool ParameterValue = true;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Animator.SetBool(ParameterName,true);
    }
}
