using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class VibrateOnTouchDown : MonoBehaviour
{
    public long milliseconds = 100;
    VibrationHandler VibrationHandler;

    void Start()
    {
        VibrationHandler = new VibrationHandler(this);
        var touches = GetComponent < DetectTouchOnThisGameObject>();
        touches.OnStart += touches_OnTouch;
        touches.OnEnd += touches_OffTouch;
    }

    void touches_OffTouch(object sender, TransformEvevntArgs e)
    {
        Debug.Log("OFF");
    }

    void touches_OnTouch(object sender, TransformEvevntArgs e)
    {
        Debug.Log(Time.realtimeSinceStartup);
        VibrationHandler.Vibrate(milliseconds);   
    }
}