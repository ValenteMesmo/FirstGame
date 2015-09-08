using System;
using UnityEngine;
using UnitySolution.InputComponents;

public class DetectTouchOnThisGameObject : MonoBehaviour
{
    void Start()
    {
        var touches = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        touches.OnStart += inputs_OnTouch;
        touches.OnEnd += inputs_OffTouch;
        touches.OnStay += inputs_OnTouchStay;
    }

    public event EventHandler<TransformEvevntArgs> OnEnd;
    private void inputs_OffTouch(object sender, TransformEvevntArgs e)
    {
        if (OnEnd != null && e.Transform.gameObject == gameObject)
            OnEnd(this, e);
    }

    public event EventHandler<TransformEvevntArgs> OnStart;
    private void inputs_OnTouch(object sender, PointEvevntArgs e)
    {
        if (OnStart != null && e.Transform.gameObject == gameObject)
            OnStart(this, e);
    }

    public event EventHandler<TransformEvevntArgs> OnStay;
    private void inputs_OnTouchStay(object sender, PointEvevntArgs e)
    {
        if (OnStay != null && e.Transform.gameObject == gameObject)
            OnStay(this, e);
    }
}
