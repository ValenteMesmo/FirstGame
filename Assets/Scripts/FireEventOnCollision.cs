using UnityEngine;
using System.Collections;
using System;

public class FireEventOnCollision : MonoBehaviour
{
    public event EventHandler<TriggerEventArgs> Enter;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (Enter != null)
            Enter(this, new TriggerEventArgs(col.collider));
    }
}