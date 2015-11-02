using UnityEngine;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ReplayGameOnTouch : MonoBehaviour
{
    public GameScreenController Controller;
    public ControlsPlayerInputs inputs;
    Animator Animator;

    void Start()
    {
        if (Controller == null)
            throw new Exception("Controller is Required!");

        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new Exception("Animator is Required!");

        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStay += touches_OnStay;
        touches.OnEnd += touches_OnEnd;
        touches.OnCancel += touches_OnCancel;

        inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.JumpButtonDown += inputs_JumpButtonDown;
        inputs.JumpButtonUp += inputs_JumpButtonUp;
    }

    void touches_OnCancel(object sender, PointEventArgs e)
    {
        Animator.SetBool("pressed", false);
    }

    void touches_OnEnd(object sender, PointEventArgs e)
    {
        Btn_Release();
    }

    void touches_OnStay(object sender, PointEventArgs e)
    {
        Btn_Pressed();
    }

    void inputs_JumpButtonUp(object sender, EventArgs e)
    {
        Btn_Release();
    }

    void inputs_JumpButtonDown(object sender, EventArgs e)
    {
        Btn_Pressed();
    }

    private void Btn_Pressed()
    {
        Animator.SetBool("pressed", true);

    }

    private void Btn_Release()
    {
        Animator.SetBool("pressed", false);

        DelayExecution(() =>  Controller.GoToMainTablePosition(), 0.4f);
    }
}