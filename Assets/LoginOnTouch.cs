using UnityEngine;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class LoginOnTouch : MonoBehaviour
{
    public event EventHandler OnClick;

    void Start()
    {
        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStart += touches_OnTouch;
    }

    void touches_OnTouch(object sender, TransformEvevntArgs e)
    {
        if (OnClick != null)
            OnClick(this, null);
    }
}
