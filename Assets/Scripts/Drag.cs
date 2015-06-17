using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Drag : MonoBehaviour
{
    private Vector2 screenPoint;
    //private Vector2 offset;

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
    }

    void Update()
    {
        if (!dragging && transform.position != MinPosition)
            transform.position = Vector3.MoveTowards(transform.position, MinPosition, maxDistPerSecondGoingBack * Time.deltaTime);
    }

    //void OnMouseDown()
    //{
    //    //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    //}

    void OnMouseDrag()
    {
        if (!GameFlags.FlippersEnabled)
        {
            dragging = true;
            Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

            if (curPosition.y > Max.position.y && curPosition.y < MinPosition.y)
                transform.position = new Vector3(transform.position.x, curPosition.y, transform.position.z); 
        }
    }

    void OnMouseUp()
    {
        if (!GameFlags.FlippersEnabled && dragging)
        {
            dragging = false;
            RigidbodyHandler.AddForce(0, MaxPowerLaunch);
        }
    }

}