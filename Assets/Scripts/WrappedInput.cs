using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WrappedInput2
{
    //TODO: transformar tudo isso em eventos!
    static WrappedInput2()
    {
        Application.logMessageReceived += HandleLog;
    }

    private static void HandleLog(string logString, string stackTrace, LogType type)
    {
        Logger.Log(logString);
    }

    public static bool TiltRight()
    {
        return UnityEngine.Input.GetKeyDown(KeyCode.S)
         || UnityEngine.Input.GetKeyDown(KeyCode.RightShift);
    }

    public static bool TiltLeft()
    {
        return UnityEngine.Input.GetKeyDown(KeyCode.A)
       || UnityEngine.Input.GetKeyDown(KeyCode.LeftShift);
    }

    public static bool LeftInputUp()
    {
        return CheckLeftTouch(TouchPhase.Ended)
            || CheckLeftKeyUp();
    }

    public static bool LeftInputPressed()
    {
        return CheckLeftTouch(TouchPhase.Began, TouchPhase.Stationary, TouchPhase.Moved)
            || CheckLeftKey();
    }

    public static bool RightInputUp()
    {
        return CheckRightTouch(TouchPhase.Ended)
            || CheckRightKeyUp();
    }

    public static bool RightInputPressed()
    {
        return CheckRightTouch(TouchPhase.Began, TouchPhase.Stationary, TouchPhase.Moved)
            || CheckRightKeyPressed();
    }

    public static bool RightInputDown()
    {
        return CheckRightTouch(TouchPhase.Began)
            || CheckRightKeyDown();
    }

    public static bool LeftInputDown()
    {
        return CheckLeftTouch(TouchPhase.Began)
         || CheckLeftKeyDown();
    }

    private static bool CheckRightTouch(params TouchPhase[] phases)
    {
        return NewMethod(phases, touch => touch.position.x > Screen.width * 0.5f);
    }

    private static bool CheckLeftTouch(params TouchPhase[] phases)
    {
        return NewMethod(phases, touch => touch.position.x < Screen.width * 0.5f);
    }

    private static bool NewMethod(TouchPhase[] phases, Func<Touch, bool> AditionalCondition)
    {
        for (var i = 0; i < UnityEngine.Input.touchCount; ++i)
        {
            Touch touch = UnityEngine.Input.GetTouch(i);
            foreach (var phase in phases)
            {
                if (touch.phase == phase)
                {
                    if (AditionalCondition(touch))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private static bool CheckLeftKey()
    {
        return UnityEngine.Input.GetKey(KeyCode.LeftArrow)
            || UnityEngine.Input.GetKey(KeyCode.Z)
            || UnityEngine.Input.GetKey(KeyCode.N)
            || UnityEngine.Input.GetKey(KeyCode.LeftControl)
            || UnityEngine.Input.GetKey(KeyCode.Escape);
    }

    private static bool CheckLeftKeyUp()
    {
        return UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow)
            || UnityEngine.Input.GetKeyUp(KeyCode.Z)
            || UnityEngine.Input.GetKeyUp(KeyCode.N)
            || UnityEngine.Input.GetKeyUp(KeyCode.LeftControl)
            || UnityEngine.Input.GetKeyUp(KeyCode.Escape);
    }

    private static bool CheckLeftKeyDown()
    {
        return UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow)
            || UnityEngine.Input.GetKeyDown(KeyCode.Z)
            || UnityEngine.Input.GetKeyDown(KeyCode.N)
            || UnityEngine.Input.GetKeyDown(KeyCode.LeftControl)
            || UnityEngine.Input.GetKeyDown(KeyCode.Escape);
    }

    private static bool CheckRightKeyPressed()
    {
        return UnityEngine.Input.GetKey(KeyCode.RightArrow)
            || UnityEngine.Input.GetKey(KeyCode.X)
            || UnityEngine.Input.GetKey(KeyCode.M)
            || UnityEngine.Input.GetKey(KeyCode.RightControl)
            || UnityEngine.Input.GetKey(KeyCode.Menu);
    }

    private static bool CheckRightKeyUp()
    {
        return UnityEngine.Input.GetKeyUp(KeyCode.RightArrow)
            || UnityEngine.Input.GetKeyUp(KeyCode.X)
            || UnityEngine.Input.GetKeyUp(KeyCode.M)
            || UnityEngine.Input.GetKeyUp(KeyCode.RightControl)
            || UnityEngine.Input.GetKeyUp(KeyCode.Menu);
    }

    private static bool CheckRightKeyDown()
    {
        return UnityEngine.Input.GetKeyDown(KeyCode.RightArrow)
            || UnityEngine.Input.GetKeyDown(KeyCode.X)
            || UnityEngine.Input.GetKeyDown(KeyCode.M)
            || UnityEngine.Input.GetKeyDown(KeyCode.RightControl)
            || UnityEngine.Input.GetKeyDown(KeyCode.Menu);
    }
}
