using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Trigger2DHandler))]
public class VibrateOnTriggerEnter : MonoBehaviour {

    IVibration VibrationHandler;
    public long duration = 100;

    protected override void OnAwake()
    {
        base.OnAwake();
        var trigger = GetComponent<Trigger2DHandler>();
        trigger.OnTriggerEnter += trigger_OnTriggerEnter;
        VibrationHandler = new VibrationHandler();
    }

    void trigger_OnTriggerEnter(object sender, Trigger2DEventArgs e)
    {
        VibrationHandler.Vibrate(duration);
    }
}
