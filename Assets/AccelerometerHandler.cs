using System;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerHandler : MonoBehaviour
{
    public float intervalInSeconds = 0.1f;
    public float deltaThatTriggerEvents = 1.0f;

    protected override void OnAwake()
    {
        base.OnAwake();
        DelayExecution(ProcessAccelerometerData, intervalInSeconds);
    }

    private float previousValues = 0f;

    public event EventHandler<EventArgs<float>> OnShakingX;

    private void ProcessAccelerometerData()
    {
        if (OnShakingX != null)
        {
            var difference = previousValues - Input.acceleration.x;
            Debug.Log(difference);
            if (difference > deltaThatTriggerEvents || difference < -deltaThatTriggerEvents)
                OnShakingX(this, new EventArgs<float>(Input.acceleration.x));
        }
        previousValues = Input.acceleration.x;
        DelayExecution(ProcessAccelerometerData, intervalInSeconds);
    }
}


public class EventArgs<T> : EventArgs
{
    public T Value;

    public EventArgs(T value)
    {
        Value = value;
    }
}