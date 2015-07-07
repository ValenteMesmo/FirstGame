using System;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerHandler : MonoBehaviour
{
    public float deltaThatTriggerEvents = 1.0f;

    void Update()
    {
        if (OnShakingX != null)
        {
            var difference = previousValues - Input.acceleration.x;
            if (difference > deltaThatTriggerEvents || difference < -deltaThatTriggerEvents)
                OnShakingX(this, new EventArgs<float>(Input.acceleration.x));
        }
        previousValues = Input.acceleration.x;
    }

    private float previousValues = 0f;

    public event EventHandler<EventArgs<float>> OnShakingX;
}

public class EventArgs<T> : EventArgs
{
    public T Value;

    public EventArgs(T value)
    {
        Value = value;
    }
}

