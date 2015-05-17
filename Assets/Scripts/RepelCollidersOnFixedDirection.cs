using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class RepelCollidersOnFixedDirection : MonoBehaviour
{
    public Vector2 Force = new Vector2(1000, 250);

    void OnCollisionEnter2D(Collision2D collision)
    {
        var rigidbody = collision.collider.gameObject.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            rigidbody.velocity = rigidbody.velocity * 0.5f;
            rigidbody.AddForce(Force);
        }
    }
}
