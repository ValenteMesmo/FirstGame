using UnityEngine;
using System.Collections;
using System;

public class TitlTable : MonoBehaviour
{
    public Rigidbody2D AddForceOnTilt;
    public float forceAmount = 200f;
    Camera Camera;

    void Start()
    {
        Camera = Camera.main;
        GetComponent<AccelerometerHandler>().OnShakingX += TitlTable_OnShakingX;
    }

    void TitlTable_OnShakingX(object sender, EventArgs<float> e)
    {
        if(e.Value > 0)
            AddForceOnTilt.AddForce(new Vector2(forceAmount, 0));
        else
            AddForceOnTilt.AddForce(new Vector2(-forceAmount, 0));
    }

    void Update()
    {
        if (WrappedInput2.TiltLeft())
        {
            AddForceOnTilt.AddForce(new Vector2(-forceAmount, 0));
        }
        else if (WrappedInput2.TiltRight())
        {
            AddForceOnTilt.AddForce(new Vector2(forceAmount, 0));
        }
    }
}