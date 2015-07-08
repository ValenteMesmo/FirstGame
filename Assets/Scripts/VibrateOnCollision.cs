using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class VibrateOnCollision : MonoBehaviour
{
    public long milliseconds = 100;

    VibrationHandler VibrationHandler;

    void Start()
    {
        VibrationHandler = new VibrationHandler(this);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        VibrationHandler.Vibrate(milliseconds);
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