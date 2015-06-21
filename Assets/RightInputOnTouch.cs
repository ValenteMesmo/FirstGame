using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;

public class RightInputOnTouch : MonoBehaviour
{
    protected override void OnAwake()
    {
        base.OnAwake();
        var inputs = GlobalComponents.GetGlobalComponent<DetectsTouchOnAnyCollidersInScene>();
        inputs.OnTouch += inputs_OnTouch;
        inputs.OffTouch += inputs_OffTouch;
    }

    void inputs_OffTouch(object sender, TransformEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            WrappedInput2.SetRightInput(false);
    }

    void inputs_OnTouch(object sender, PointEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            WrappedInput2.SetRightInput(true);
    }
}