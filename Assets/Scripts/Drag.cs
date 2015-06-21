using System.Collections.Generic;
using UnityEngine;
using UnitySolution.InputComponents;

[RequireComponent(typeof(BoxCollider2D))]
public class Drag : MonoBehaviour
{
    private Vector2 screenPoint;

    private Vector3 MinPosition;
    public Transform Max;
    public float maxDistPerSecondGoingBack = 100f;
    bool dragging;

    public float MaxPowerLaunch = 4000f;
    public LauchCollidingRigidBodies laucher;

    protected override void OnAwake()
    {
        base.OnAwake();
        MinPosition = transform.position;
        Vibration = new VibrationHandler(this);
        yPreviousValue = transform.position.y;

        var input = GlobalComponents.GetGlobalComponent<DetectsTouchOnAnyCollidersInScene>();
        input.OnTouch += input_OnTouch;
        input.OffTouch += input_OffTouch;
    }

    void input_OffTouch(object sender, TransformEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            touchOff();
    }

    void input_OnTouch(object sender, PointEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            touchOn(e.Vector2);
    }

    void Update()
    {
        if (WrappedInput2.GetJumpPressed())
        {
            touchOn(Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y - 0.1f)));
        }
        if (WrappedInput2.GetJumpUp())
        {
            touchOff();
        }


        if (!dragging && transform.position != MinPosition)
            transform.position = Vector3.MoveTowards(transform.position, MinPosition, maxDistPerSecondGoingBack * Time.deltaTime);
        
       
    }

    private void touchOn(Vector2 point)
    {
        dragging = true;

        Vector2 curPosition = Camera.main.ScreenToWorldPoint(point);

        if (curPosition.y > Max.position.y && curPosition.y < MinPosition.y)
            //TODO: Vector3.MoveTowards
            transform.position = new Vector3(transform.position.x, curPosition.y, transform.position.z);

        if (!vibrating && curPosition.y < yPreviousValue)
        {
            vibrating = true;
            Vibration.Vibrate(5);

            DelayExecution(() => vibrating = false, 0.05f);
        }
        yPreviousValue = curPosition.y;
    }

    bool vibrating;

    float yPreviousValue;

    VibrationHandler Vibration;

    private void touchOff()
    {
        dragging = false;

        if (laucher.BodiesCount > 0)
        {
            var percentage = -(((transform.position.y - MinPosition.y) / MinPosition.y) * 100);

            if (percentage > 0.01f)
            {
                var force = (MaxPowerLaunch / 100) * percentage;

                Vibration.Vibrate(50);
                laucher.Launch(force);
            }
        }
    }
}