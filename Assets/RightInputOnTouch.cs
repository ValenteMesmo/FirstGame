using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;

public class RightInputOnTouch : MonoBehaviour
{
    ControlsPlayerInputs inputs;

    protected void Awake()
    {
        
        var touches = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        touches.OnStart += inputs_OnTouch;
        touches.OnStay += inputs_OnTouch;
        touches.OnEnd += inputs_OffTouch;
        touches.OnCancel += inputs_OffTouch;

        inputs = GlobalComponents.Get<ControlsPlayerInputs>();
    }

    void inputs_OffTouch(object sender, PointEventArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            inputs.ReleaseRightButton();
    }

    void inputs_OnTouch(object sender, PointEventArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            inputs.PressRightButton();
    }
}