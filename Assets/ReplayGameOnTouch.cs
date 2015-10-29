using UnityEngine;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ReplayGameOnTouch : MonoBehaviour
{
    public GameScreenController Controller;
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

        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.JumpButtonDown += inputs_JumpButtonDown;
        inputs.JumpButtonUp += inputs_JumpButtonUp;
    }

    void touches_OnEnd(object sender, TransformEvevntArgs e)
    {
        Btn_Release();

    }

    void touches_OnStay(object sender, TransformEvevntArgs e)
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