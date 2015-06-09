using System;
using UnityEngine;

public class AccelerometerHandler : MonoBehaviour
{
    public float intervalInSeconds = 0.5f;
    public float deltaThatTriggerEvents = 0.5f;

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