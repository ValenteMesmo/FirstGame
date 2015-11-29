using UnityEngine;
using System.Collections;

public class SetBoolOnCollision : MonoBehaviour
{
    public Animator TargetAnimator;
    public string Parameter;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude >= 3f)
            TargetAnimator.SetTrigger(Parameter);
    }
}
