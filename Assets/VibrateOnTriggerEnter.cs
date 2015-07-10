using UnityEngine;

public class VibrateOnTriggerEnter : MonoBehaviour
{
    IVibration VibrationHandler;
    public long duration = 100;

    void Start()
    {
        VibrationHandler = new VibrationHandler(this);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            VibrationHandler.Vibrate(duration);
    }
}
