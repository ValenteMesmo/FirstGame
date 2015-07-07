using UnityEngine;

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
        vibrationHandler = new VibrationHandler(this);
    }

    bool accelerometerOnCooldown = false;

    void TitlTable_OnShakingX(object sender, EventArgs<float> e)
    {
        if (accelerometerOnCooldown == false)
        {
            if (e.Value > 0)
                ExecuteRightTilt(forceAmount);
            else
                ExecuteRightTilt(-forceAmount);
            accelerometerOnCooldown = true;
            DelayExecution(() => accelerometerOnCooldown = false, 0.5f);
        }
    }
    
    void Update()
    {
        if (WrappedInput2.TiltLeft())
            ExecuteRightTilt(-forceAmount);
        else if (WrappedInput2.TiltRight())
            ExecuteRightTilt(forceAmount);
    }

    private void ExecuteRightTilt(float forceAmount)
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

            AddForceOnTilt.AddForce(new Vector2(forceAmount, 0));
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