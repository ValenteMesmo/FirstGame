using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Trigger2DHandler))]
[RequireComponent(typeof(SpriteRendererHandler))]
public class ChangeColorOnTriggerStay : MonoBehaviour
{
    private Color OriginalColor;
    public Color NewColor;

    ISpriteRendererHandler SpriteRendererHandler;
    protected void Start()
    {
        var trigger = GetComponent<Trigger2DHandler>();
        SpriteRendererHandler = GetComponent<SpriteRendererHandler>();
        OriginalColor = new Color(
            SpriteRendererHandler.Red,
            SpriteRendererHandler.Green,
            SpriteRendererHandler.Blue,
            SpriteRendererHandler.Alpha);
        trigger.OnTriggerStay += trigger_OnTriggerEnter;
        trigger.OnTriggerExit += trigger_OnTriggerExit;
        base.OnAwake();
    }

    void trigger_OnTriggerExit(object sender, Trigger2DEventArgs e)
    {
        if (e.Tag == "Player")
            SpriteRendererHandler.SetColor(OriginalColor.r, OriginalColor.g, OriginalColor.b, OriginalColor.a);
    }

    void trigger_OnTriggerEnter(object sender, Trigger2DEventArgs e)
    {
        if (e.Tag == "Player")
            SpriteRendererHandler.SetColor(NewColor.r, NewColor.g, NewColor.b, NewColor.a);
    }
}
