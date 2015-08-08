using UnityEngine;
using System.Collections;
using System;

public class SetAnimatorBoolBasedOnGlobalComponents : MonoBehaviour
{
    private Animator Animator;
    private bool currentIsDead;

    void Start()
    {
        Animator = transform.parent.GetComponent<Animator>();
        if (Animator == null)
            throw new Exception("Sorry! Im trying to get the animator from the parent object~");
    }

    void Update()
    {
        Animator.SetBool("dead", GlobalComponents.HideFireflyWave || currentIsDead);
        if (GlobalComponents.HideFireflyWave)
            currentIsDead = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && currentIsDead == false)
        {
            currentIsDead = true;
        }
    }
}
