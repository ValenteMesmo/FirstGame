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
            var difference = previousX - Input.acceleration.x;
            if (difference > deltaThatTriggerEvents || difference < -deltaThatTriggerEvents)
                OnShakingX(this, new EventArgs<float>(Input.acceleration.x));
        }
        if(OnShakingZ!=null)
        { 
            var difference = previousZ - Input.acceleration.z;
            if (difference > deltaThatTriggerEvents || difference < -deltaThatTriggerEvents)
                OnShakingZ(this, new EventArgs<float>(Input.acceleration.z));
        }
        previousZ = Input.acceleration.z;
        previousX = Input.acceleration.x;
    }

    private float previousZ = 0f;
    private float previousX = 0f;

    public event EventHandler<EventArgs<float>> OnShakingX;
    public event EventHandler<EventArgs<float>> OnShakingZ;
}

public class EventArgs<T> : EventArgs
{
    public T Value;

    public EventArgs(T value)
    {
        Value = value;
    }
}

