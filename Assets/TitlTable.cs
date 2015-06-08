using UnityEngine;
using System.Collections;

public class TitlTable : MonoBehaviour
{
    public Rigidbody2D AddForceOnTilt;
    public float forceAmount = 200f;
    Camera Camera;

    void Start()
    {
        Camera = Camera.main;
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
