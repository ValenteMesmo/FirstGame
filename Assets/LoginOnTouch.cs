using UnityEngine;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class LoginOnTouch : MonoBehaviour
{
    public event EventHandler OnClick;
    Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new Exception("Animator is Required!");

        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStay += inputs_JumpButtonDown;
        touches.OnEnd += inputs_JumpButtonUp;
        touches.OnCancel += touches_OnCancel;
    }

    void touches_OnCancel(object sender, PointEventArgs e)
    {
        Animator.SetBool("pressed", false);
    }

    void inputs_JumpButtonUp(object sender, EventArgs e)
    {
        Animator.SetBool("pressed", false);
        if (OnClick != null)
            OnClick(this, null);
    }

    void inputs_JumpButtonDown(object sender, EventArgs e)
    {
        Animator.SetBool("pressed", true);
    }
}
