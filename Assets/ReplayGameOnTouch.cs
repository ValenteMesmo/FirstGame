using UnityEngine;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ReplayGameOnTouch : MonoBehaviour
{
    public Transform LocationOfGameOverMenu;

    void Start()
    {
        if (LocationOfGameOverMenu == null)
            throw new Exception("LocationOfGameOverMenu is Required!");

        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStart += touches_OnTouch;

        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.JumpButtonDown += inputs_JumpButtonDown;
    }

    void inputs_JumpButtonDown(object sender, EventArgs e)
    {
        Camera.main.transform.position = LocationOfGameOverMenu.position;
    }

    void touches_OnTouch(object sender, TransformEvevntArgs e)
    {
        Camera.main.transform.position = LocationOfGameOverMenu.position;
    }
}