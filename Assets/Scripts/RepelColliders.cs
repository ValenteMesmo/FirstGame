using UnityEngine;
using System.Collections;
using System;

public class RepelColliders : MonoBehaviour
{
    public float ExplosionStrength = 1400f;

    void Start()
    {
        if (GetComponent<Collider2D>() == null)
            throw new NullReferenceException("Collider2D is required for 'RepelColliders'");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        {
            collision.rigidbody.velocity *= 0.5f;
            var dir = collision.rigidbody.position - (Vector2)transform.position;
            collision.rigidbody.AddForce(dir.normalized * ExplosionStrength);
        }
    }
}