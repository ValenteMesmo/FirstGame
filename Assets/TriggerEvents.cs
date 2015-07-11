using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public class TriggerEvents : MonoBehaviour
{
    void Start()
    {
        if (GetComponents<Collider2D>().Any(f => f.isTrigger) == false)
            throw new Exception("There need to be an Collider2D marked as Trigger");
    }

    public event EventHandler<TriggerEventArgs> Enter;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (Enter != null)
            Enter(this, new TriggerEventArgs(col));
    }

    public event EventHandler<TriggerEventArgs> Stay;
    void OnTriggerStay2D(Collider2D col)
    {
        if (Stay != null)
            Stay(this, new TriggerEventArgs(col));
    }

    public event EventHandler<TriggerEventArgs> Exit;
    void OnTriggerExit2D(Collider2D col)
    {
        if (Exit != null)
            Exit(this, new TriggerEventArgs(col));
    }
}

public class TriggerEventArgs : EventArgs
{
    public readonly Collider2D Collider;

    public TriggerEventArgs(Collider2D col)
    {
        Collider = col;
    }
}
