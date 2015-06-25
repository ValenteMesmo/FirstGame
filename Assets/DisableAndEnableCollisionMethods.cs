using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DisableAndEnableCollisionMethods : MonoBehaviour
{
    Collider2D Collider;
    void Start()
    {
        Collider = GetComponent < Collider2D>();

    }

    void EnableCollisions()
    {
        Collider.enabled = true;
    }

    void DisableCollisions()
    {
        Collider.enabled = false;
    }
}
