using System;
using UnityEngine;

public class TitlTable : MonoBehaviour
{
    public float forceAmount = 200f;
    Camera Camera;
    Color CameraColor;
    public GameScreenController Controller;

    IVibration vibrationHandler;

    bool cooldown = false;

    void Start()
    {
        Camera = Camera.main;
        CameraColor = Camera.backgroundColor;
        var accelerometer = GetComponent<AccelerometerHandler>();
        accelerometer.OnShakingX += TitlTable_OnShakingX;

        if (Controller == null)
            throw new NullReferenceException("GameScreenController");
        
        vibrationHandler = new VibrationHandler(this);
    }

    bool accelerometerOnCooldown = false;

    void TitlTable_OnShakingX(object sender, EventArgs<float> e)
    {
        if (Controller.IsOnMainMenu() == false && accelerometerOnCooldown == false)
        {
            if (e.Value > 0)
                ExecuteTilt(-forceAmount);
            else
                ExecuteTilt(forceAmount);
            accelerometerOnCooldown = true;
            DelayExecution(() => accelerometerOnCooldown = false, 0.5f);
        }
    }

    void Update()
    {
        if (WrappedInput2.TiltLeft())
            ExecuteTilt(-forceAmount);
        else if (WrappedInput2.TiltRight())
            ExecuteTilt(forceAmount);
    }

    private void ExecuteTilt(float forceAmount)
    {
        if (cooldown)
        {
            GlobalComponents.FlippersEnabled = false;
            Camera.backgroundColor = Color.black;
        }
        else
        {
            SetTiltCooldown();
            if (GlobalComponents.FlippersEnabled)
                Camera.backgroundColor = Color.grey;

            foreach (var ball in GlobalComponents.Balls)
            {
                ball.AddForce(new Vector2(forceAmount, 0));
            }

            DelayExecution(() =>
            {
                if (GlobalComponents.FlippersEnabled)
                    Camera.backgroundColor = CameraColor;
            }, 0.5f);
        }

        vibrationHandler.Vibrate(300);
    }

    private void SetTiltCooldown()
    {
        cooldown = true;
        DelayExecution(() => cooldown = false, UnityEngine.Random.Range(0.1f, 10f));
    }
}