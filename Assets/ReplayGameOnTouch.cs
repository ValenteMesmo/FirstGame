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
        touches.OnStay += inputs_JumpButtonDown;
        touches.OnEnd += inputs_JumpButtonUp;
        touches.OnCancel += touches_OnCancel;

        if (inputs == null)
            throw new NullReferenceException("ControlsPlayerInputs");
        inputs.JumpButtonDown += inputs_JumpButtonDown;
        inputs.JumpButtonUp += inputs_JumpButtonUp;
    }

    void touches_OnCancel(object sender, PointEventArgs e)
    {
        Animator.SetBool("pressed", false);
    }

    void inputs_JumpButtonUp(object sender, EventArgs e)
    {
        Animator.SetBool("pressed", false);

        DelayExecution(() => Controller.GoToMainTablePosition(), 0.2f);
    }

    void inputs_JumpButtonDown(object sender, EventArgs e)
    {
        Animator.SetBool("pressed", true);
    }
}