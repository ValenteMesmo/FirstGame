using UnityEngine;
using System.Collections;
using System;

public class PassThruBehaviour : MonoBehaviour
{
    public event EventHandler OnPassThru;
    private bool goingUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        goingUp = other.GetComponent<Rigidbody2D>().velocity.y > 0;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (OnPassThru != null && (PassThruFromBelow(other) || PassThruFromAbove(other)))
            OnPassThru(this, default(EventArgs));
    }

    private bool PassThruFromAbove(Collider2D other)
    {
        return goingUp && other.GetComponent<Rigidbody2D>().velocity.y > 0;
    }

    private bool PassThruFromBelow(Collider2D other)
    {
        return !goingUp && other.GetComponent<Rigidbody2D>().velocity.y < 0;
    }
}
