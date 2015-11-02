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
    }

    void touches_OnTouch(object sender, PointEventArgs e)
    {
        VibrationHandler.Vibrate(milliseconds);   
    }
}