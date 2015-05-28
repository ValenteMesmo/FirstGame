using UnityEngine;
using System.Collections;

public class VibrationComponent : MonoBehaviour
{
    public long milliseconds;

    protected override void OnAwake()
    {
        new VibrateOnCollision(new VibrationHandler(), this, milliseconds);
    }
}

public class VibrateOnCollision
{
    IVibration Vibration;
    long Milliseconds;

    public VibrateOnCollision(IVibration vibration, ICollider2D collider, long milliseconds)
    {
        Vibration = vibration;
        Milliseconds = milliseconds;
        collider.OnCollisionEnter += collider_OnCollisionEnter;
    }

    void collider_OnCollisionEnter(object sender, Collision2DEventArgs e)
    {
        Vibration.Vibrate(Milliseconds);
    }
}