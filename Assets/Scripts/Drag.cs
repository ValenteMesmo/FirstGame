using System;
using System.Collections.Generic;
using UnityEngine;
using UnitySolution.InputComponents;

[RequireComponent(typeof(BoxCollider2D))]
public class Drag : MonoBehaviour
{
     private AudioClipPlus Audio;
     public Animator CameraAnimator;
  
        
    private Vector2 screenPoint;
    public GameObject ExplosionPrefab;

    private Vector3 MinPosition;
    public Transform Max;
    public float maxDistPerSecondGoingBack = 100f;
    bool dragging;

    public float MaxPowerLaunch = 4000f;
    public LauchCollidingRigidBodies laucher;

    protected void Awake()
    {
        if (ExplosionPrefab == null)
            throw new NullReferenceException("ExplosionPrefab");
        Audio = GetComponent<AudioClipPlus>();

        MinPosition = transform.position;
        Vibration = new VibrationHandler(this);
        yPreviousValue = transform.position.y;

        var input = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        input.OnStart += input_OnTouch;
        input.OnStay += input_OnTouch;
        input.OnEnd += input_OffTouch;
        input.OnCancel += input_OffTouch;
    }

    void input_OffTouch(object sender, PointEventArgs e)
    {
        if (e.Transform.gameObject == gameObject)
            touchOff();
    }

    void input_OnTouch(object sender, PointEventArgs e)
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
        {
            //TODO: Vector3.MoveTowards
            transform.position = new Vector3(transform.position.x, curPosition.y, transform.position.z);

            if (!vibrating && curPosition.y < yPreviousValue)
            {
                vibrating = true;
                Vibration.Vibrate(5);

                DelayExecution(() => vibrating = false, 0.1f);
            }
        }
        yPreviousValue = curPosition.y;
    }

    bool vibrating;

    float yPreviousValue;

    VibrationHandler Vibration;
    bool onCooldown;
    private void touchOff()
    {
        dragging = false;

        if (onCooldown == false)
        {
            onCooldown = true;
            DelayExecution(() => onCooldown = false, 0.5f);

            if (laucher.BodiesCount > 0)
            {
                var percentage = -(((transform.position.y - MinPosition.y) / MinPosition.y) * 100);

                if (percentage > 0.01f)
                {
                    var force = (MaxPowerLaunch / 100) * percentage;

                    
                    laucher.Launch(force);
                }
            } 
        }
        Vibration.Vibrate(50);
        CameraAnimator.SetTrigger("easyShake");
        Audio.Play();
        Instantiate(ExplosionPrefab, transform.parent.transform.position, Quaternion.identity);
    }
}