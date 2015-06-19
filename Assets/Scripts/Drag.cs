using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Drag : MonoBehaviour
{
    private Vector2 screenPoint;

    private Vector3 MinPosition;
    public Transform Max;
    public float maxDistPerSecondGoingBack = 100f;
    bool dragging;

    public float MaxPowerLaunch = 4000f;

    public RigidBody2DHandler RigidbodyHandler;

    protected override void OnAwake()
    {
        base.OnAwake();
        MinPosition = transform.position;
        Vibration = new VibrationHandler(this);
        yPreviousValue = transform.position.y;
    }

    void Update()
    {
        if (!dragging && transform.position != MinPosition)
            transform.position = Vector3.MoveTowards(transform.position, MinPosition, maxDistPerSecondGoingBack * Time.deltaTime);
    }

    //TODO: change to touchinput
    //TODO: keyboard compatibility
    void OnMouseDrag()
    {
        if (!GameFlags.FlippersEnabled)
        {
            dragging = true;
            Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

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
    }

    bool vibrating;

    float yPreviousValue;

    VibrationHandler Vibration;

    void OnMouseUp()
    {
        if (!GameFlags.FlippersEnabled && dragging)
        {
            dragging = false;

            var percentage = -(((transform.position.y - MinPosition.y) / MinPosition.y) * 100);
            var force = (MaxPowerLaunch / 100) * percentage;

            Vibration.Vibrate(50);
            RigidbodyHandler.AddForce(0, force);
        }
    }
}