using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TitlTable : MonoBehaviour
{
    public Rigidbody2D AddForceOnTilt;
    public float forceAmount = 200f;
    Camera Camera;
    Color CameraColor;

    IVibration vibrationHandler;

    bool cooldown = false;

    void Start()
    {
        Camera = Camera.main;
        CameraColor = Camera.backgroundColor;
        GetComponent<AccelerometerHandler>().OnShakingX += TitlTable_OnShakingX;
        vibrationHandler = new VibrationHandler();
    }

    bool accelerometerOnCooldown = false;

    void TitlTable_OnShakingX(object sender, EventArgs<float> e)
    {
        if (GameFlags.FlippersEnabled && accelerometerOnCooldown == false)
        {
            if (e.Value > 0)
                ExecuteRightTilt();
            else
                ExecuteLeftTilt();
            accelerometerOnCooldown = true;
            DelayExecution(() => accelerometerOnCooldown = false, 0.5f);
        }
    }


    void Update()
    {
        if (GameFlags.FlippersEnabled)
        {
            if (WrappedInput2.TiltLeft())
                ExecuteLeftTilt();
            else if (WrappedInput2.TiltRight())
                ExecuteRightTilt();
        }
    }

    private void ExecuteRightTilt()
    {

        if (cooldown)
        {
            GameFlags.FlippersEnabled = false;
            Camera.backgroundColor = Color.black;
        }
        else
        {
            SetTiltCooldown();
            Camera.backgroundColor = Color.grey;

            AddForceOnTilt.AddForce(new Vector2(forceAmount, 0));
            DelayExecution(() =>
            {
                if (GameFlags.FlippersEnabled)
                    Camera.backgroundColor = CameraColor;
            }, 0.5f);
            vibrationHandler.Vibrate(300);
        }
    }

    private void SetTiltCooldown()
    {
        cooldown = true;
        DelayExecution(() => cooldown = false, UnityEngine.Random.Range(0.1f, 10f));
    }

    private void ExecuteLeftTilt()
    {
        if (cooldown)
        {
            GameFlags.FlippersEnabled = false;
            Camera.backgroundColor = Color.black;
        }
        else
        {
            SetTiltCooldown();
            Camera.backgroundColor = Color.grey;

            AddForceOnTilt.AddForce(new Vector2(-forceAmount, 0));
            DelayExecution(() =>
            {
                if (GameFlags.FlippersEnabled)
                    Camera.backgroundColor = CameraColor;
            }, 0.5f);
            vibrationHandler.Vibrate(300);
        }
    }
}