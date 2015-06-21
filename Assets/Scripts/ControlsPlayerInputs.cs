using UnityEngine;
using System.Collections;
using System;

public class ControlsPlayerInputs : MonoBehaviour
{
    public event EventHandler LeftButtonDown;
    public event EventHandler LeftButtonUp;
    public event EventHandler LeftButtonPressed;

    public event EventHandler RightButtonDown;
    public event EventHandler RightButtonUp;
    public event EventHandler RightButtonPressed;

    public event EventHandler JumpButtonDown;
    public event EventHandler JumpButtonUp;
    public event EventHandler JumpButtonPressed;

    private const string JUMP = "Jump";

    bool isLeftButtonDown;
    bool isRightButtonDown;

    void Update()
    {
        if (LeftButtonDown != null && Input.GetKeyDown(KeyCode.Z))
            LeftButtonDown(this, null);
        if (LeftButtonPressed != null && Input.GetKey(KeyCode.Z))
            LeftButtonPressed(this, null);
        if (LeftButtonUp != null && Input.GetKeyUp(KeyCode.Z))
            LeftButtonUp(this, null);

        if (RightButtonDown != null && Input.GetKeyDown(KeyCode.X))
            RightButtonDown(this, null);
        if (RightButtonPressed != null && Input.GetKey(KeyCode.X))
            RightButtonPressed(this, null);
        if (RightButtonUp != null && Input.GetKeyUp(KeyCode.X))
            RightButtonUp(this, null);

        if (JumpButtonDown != null && Input.GetButtonDown(JUMP))
            JumpButtonDown(this, null);
        if (JumpButtonPressed != null && Input.GetButton(JUMP))
            JumpButtonPressed(this, null);
        if (JumpButtonUp != null && Input.GetButtonUp(JUMP))
            JumpButtonUp(this, null);
    }

    public void PressLeftButton()
    {
        if (isLeftButtonDown == false)
        {
            isLeftButtonDown = true;
            if (LeftButtonDown != null)
                LeftButtonDown(this, null);
        }

        if (LeftButtonPressed != null)
            LeftButtonPressed(this, null);
    }

    public void ReleaseLeftButton()
    {
        if (isLeftButtonDown)
        {
            isLeftButtonDown = false;
            if (LeftButtonUp != null)
                LeftButtonUp(this, null);
        }
    }

    public void PressRightButton()
    {
        if (isRightButtonDown == false)
        {
            isRightButtonDown = true;
            if (RightButtonDown != null)
                RightButtonDown(this, null);
        }

        if (RightButtonPressed != null)
            RightButtonPressed(this, null);
    }

    public void ReleaseRightButton()
    {
        if (isRightButtonDown)
        {
            isRightButtonDown = false;
            if (RightButtonUp != null)
                RightButtonUp(this, null);
        }
    }
}
