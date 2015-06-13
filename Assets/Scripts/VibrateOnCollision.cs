using UnityEngine;
using System.Collections;

public class VibrateOnCollision : MonoBehaviour
{
    public long milliseconds =100;

    protected override void OnAwake()
    {
        new VibrateOnCollision2(new VibrationHandler(), GetComponent<BaseCollider2DHandler>(), milliseconds);
    }
}

public class VibrateOnCollision2
{
    IVibration Vibration;
    long Milliseconds;

    public VibrateOnCollision2(IVibration vibration, ICollider2DHandler collider, long milliseconds)
    {
        Vibration = vibration;
        Milliseconds = milliseconds;
        collider.OnCollisionEnter += collider_OnCollisionEnter;
    }

    void collider_OnCollisionEnter(object sender, Collision2DEventArgs e)
    {
        try
        {
            Vibration.Vibrate(Milliseconds);
        }
        catch (System.Exception ex)
        {
            Logger.Log(ex.ToString());
            // GuiTextDebug.debug(ex.ToString());
        }
    }
}


public static class Logger
{
    static GUIText btnTexts;
    public static void Log(string msg)
    {
        if (btnTexts == null)
        {
            GameObject go = new GameObject("GUIText");
            btnTexts = go.AddComponent<GUIText>();
            go.transform.position = new Vector3(0.0f, 0.9f, 0.0f);
            btnTexts.fontSize = 40;
        }
        btnTexts.text = msg;
    }

}