using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DisableColliderOnCollision : MonoBehaviour
{
    Collider2D Collider;

    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Collider.enabled = false;
        }
    }
}
