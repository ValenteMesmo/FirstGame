using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class RepelColliders : MonoBehaviour
{
    public float ExplosionStrength = 1400f;

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