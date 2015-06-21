using UnityEngine;

public static class WrappedInput2
{
    //TODO: transformar tudo isso em eventos?
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

    static bool leftInput;
    public static bool GetLeftInputPressed()
    {
        return leftInput || CheckLeftKey();
    }

    static bool rightInput;
    public static bool GetRightInputPressed()
    {
        return rightInput || CheckRightKeyPressed();
    }

    public static void SetRightInput(bool pressed)
    {
        rightInput = pressed;
    }

    public static void SetLeftInput(bool pressed)
    {
        leftInput = pressed;
    }


    private static bool CheckLeftKey()
    {
        return UnityEngine.Input.GetKey(KeyCode.LeftArrow)
            || UnityEngine.Input.GetKey(KeyCode.Z)
            || UnityEngine.Input.GetKey(KeyCode.N)
            || UnityEngine.Input.GetKey(KeyCode.LeftControl);
    }



    private static bool CheckRightKeyPressed()
    {
        return UnityEngine.Input.GetKey(KeyCode.RightArrow)
            || UnityEngine.Input.GetKey(KeyCode.X)
            || UnityEngine.Input.GetKey(KeyCode.M)
            || UnityEngine.Input.GetKey(KeyCode.RightControl);
    }



    public static void Reset()
    {
        leftInput = false;
        rightInput = false;
    }

    public static bool GetJumpPressed()
    {
        return Input.GetButton("Jump");
    }

    public static bool GetJumpUp()
    {
        return Input.GetButtonUp("Jump");
    }
}