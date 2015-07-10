using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SetAnimatorBoolBasedOnGlobalComponents : MonoBehaviour
{
    Animator Animator;
    bool currentIsDead;

    void Start()
    {
        Animator = GetComponent<Animator>();
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
