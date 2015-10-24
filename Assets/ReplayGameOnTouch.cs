using UnityEngine;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ReplayGameOnTouch : MonoBehaviour
{
    public GameScreenController Controller;

    void Start()
    {
        if (Controller == null)
            throw new Exception("Controller is Required!");
       
        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStart += touches_OnTouch;

        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.JumpButtonDown += inputs_JumpButtonDown;
    }

    void inputs_JumpButtonDown(object sender, EventArgs e)
    {
        Controller.GoToMainTablePosition();
    }

    void touches_OnTouch(object sender, TransformEvevntArgs e)
    {
        Controller.GoToMainTablePosition();
    }
}