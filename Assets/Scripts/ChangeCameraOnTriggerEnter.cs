using UnityEngine;
using System.Collections;
using System;

public class ChangeCameraOnTriggerEnter : MonoBehaviour
{
    public Transform TargetPosition;
    public Transform CameraPosition;
    public float CameraZoom = 13f;

    protected override void OnAwake()
    {
        new WarpOnTriggerEnter(this, TargetPosition.position.x, TargetPosition.position.y);
        new MoveCameraOnTriggerEnter(
            this,
            new WrappedCamera(Camera.main),
            CameraPosition.position.x,
            CameraPosition.position.y,
            CameraZoom);
    }
}

//TODO: mover essas classes para um projeto que não referencie o unityengine dll
public class MoveCameraOnTriggerEnter
{
    float Destiny_X;
    float Destiny_Y;
    float Size;
    ICamera Camera;

    public MoveCameraOnTriggerEnter(
        ITrigger2D trigger,
        ICamera camera,
        float destiny_x,
        float destiny_y,
        float size)
    {
        Camera = camera;
        Destiny_X = destiny_x;
        Destiny_Y = destiny_y;
        Size = size;
        trigger.OnTriggerEnter += trigger_OnTriggerEnter;
    }

    void trigger_OnTriggerEnter(object sender, Trigger2DEventArgs e)
    {
        Camera.SetPosition(Destiny_X, Destiny_Y);
        Camera.Size = Size;
    }
}

public class WarpOnTriggerEnter
{
    float Destiny_X;
    float Destiny_Y;

    public WarpOnTriggerEnter(
        ITrigger2D trigger,
        float destiny_x,
        float destiny_y)
    {
        Destiny_X = destiny_x;
        Destiny_Y = destiny_y;
        trigger.OnTriggerEnter += trigger_OnTriggerEnter;
    }

    void trigger_OnTriggerEnter(object sender, Trigger2DEventArgs e)
    {
        e.Transform.SetPosition(Destiny_X, Destiny_Y);
    }
}