using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;

public class LeftInputOnTouch : MonoBehaviour
{
    ControlsPlayerInputs inputs;

    protected void Awake()
    {        
        var touches = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        touches.OnStart += inputs_OnTouch;
        touches.OnStay += inputs_OnTouch;
        touches.OnEnd += inputs_OffTouch;       

        inputs = GlobalComponents.Get<ControlsPlayerInputs>();
    }

    void inputs_OffTouch(object sender, TransformEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
        {
            inputs.ReleaseLeftButton();
        }
    }

    void inputs_OnTouch(object sender, PointEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
        {
            inputs.PressLeftButton();
        }
    }
}