using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerHeadAnimation : MonoBehaviour {

    Animator Animator;
    public Rigidbody2D Rigidbody2D;

    public float speedToCHangeAnimation = 5f;

    protected void Awake()
    {
        Animator = GetComponent<Animator>();
        //Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log(Rigidbody2D.velocity.ToString());
        Animator.SetBool("HighSpeed", IsMovingOnHighVelocity());
    }

    private bool IsMovingOnHighVelocity()
    {
        return Rigidbody2D.velocity.x < -speedToCHangeAnimation ||
            Rigidbody2D.velocity.y < -speedToCHangeAnimation ||
            Rigidbody2D.velocity.x > speedToCHangeAnimation ||
            Rigidbody2D.velocity.y > speedToCHangeAnimation;
    }
}
