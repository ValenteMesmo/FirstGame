using UnityEngine;
using System.Collections;
using System;

public class TimeScale : MonoBehaviour
{
    public float Value = 1f;
    DateTime cooldown = DateTime.MinValue;

    void Start()
    {
        Time.timeScale = Value;
    }

    void Update()
    {
        if (cooldown != DateTime.MinValue &&  cooldown < DateTime.Now)
        {
            cooldown = DateTime.MinValue;
            Time.timeScale = Value;
        }        
    }

    public void Freeze(float ticks)
    {
        Time.timeScale = 0;
        cooldown = DateTime.Now.AddMilliseconds(ticks);
    }
}
