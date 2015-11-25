using UnityEngine;

public class VibrateOnTriggerExit : MonoBehaviour
{
    IVibration VibrationHandler;
    public long duration = 100;

    void Start()
    {
        VibrationHandler = new VibrationHandler(this);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            VibrationHandler.Vibrate(duration);
    }
}
