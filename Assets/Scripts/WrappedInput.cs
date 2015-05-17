using System;
using UnityEngine;

public static class WrappedInput2
{
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
            || UnityEngine.Input.GetKey(KeyCode.LeftControl);
    }

    private static bool CheckLeftKeyUp()
    {
        return UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow)
            || UnityEngine.Input.GetKeyUp(KeyCode.Z)
            || UnityEngine.Input.GetKeyUp(KeyCode.N)
            || UnityEngine.Input.GetKeyUp(KeyCode.LeftControl);
    }

    private static bool CheckLeftKeyDown()
    {
        return UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow)
            || UnityEngine.Input.GetKeyDown(KeyCode.Z)
            || UnityEngine.Input.GetKeyDown(KeyCode.N)
            || UnityEngine.Input.GetKeyDown(KeyCode.LeftControl);
    }

    private static bool CheckRightKeyPressed()
    {
        return UnityEngine.Input.GetKey(KeyCode.RightArrow)
            || UnityEngine.Input.GetKey(KeyCode.X)
            || UnityEngine.Input.GetKey(KeyCode.M)
            || UnityEngine.Input.GetKey(KeyCode.RightControl);
    }

    private static bool CheckRightKeyUp()
    {
        return UnityEngine.Input.GetKeyUp(KeyCode.RightArrow)
            || UnityEngine.Input.GetKeyUp(KeyCode.X)
            || UnityEngine.Input.GetKeyUp(KeyCode.M)
            || UnityEngine.Input.GetKeyUp(KeyCode.RightControl);
    }

    private static bool CheckRightKeyDown()
    {
        return UnityEngine.Input.GetKeyDown(KeyCode.RightArrow)
            || UnityEngine.Input.GetKeyDown(KeyCode.X)
            || UnityEngine.Input.GetKeyDown(KeyCode.M)
            || UnityEngine.Input.GetKeyDown(KeyCode.RightControl);
    }
}
