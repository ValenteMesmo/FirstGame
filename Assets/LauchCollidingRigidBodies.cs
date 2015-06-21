using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class LauchCollidingRigidBodies : MonoBehaviour
{
    private List<Rigidbody2D> RigidbodyHandlers = new List<Rigidbody2D>();
    void OnCollisionEnter2D(Collision2D col)
    {
        var body = col.gameObject.GetComponent<Rigidbody2D>();
        if (!RigidbodyHandlers.Contains(body))
            RigidbodyHandlers.Add(body);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        var body = col.gameObject.GetComponent<Rigidbody2D>();
        if (RigidbodyHandlers.Contains(body))
            RigidbodyHandlers.Remove(body);
    }

    public int BodiesCount { get { return RigidbodyHandlers.Count; } }


    private bool onCooldown;
    public void Launch(float force)
    {
        if (onCooldown == false)
        {
            onCooldown = true;
            foreach (var item in RigidbodyHandlers)
            {
                item.AddForce(new Vector2(0, force));
            }
            DelayExecution(() => onCooldown = false, 0.5f);
        }
    }
}
