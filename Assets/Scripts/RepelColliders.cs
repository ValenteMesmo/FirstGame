using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2dHandler))]
public class RepelColliders : MonoBehaviour
{
    public float ExplosionStrength = 1400f;

    protected override void OnAwake()
    {
        new MyClass(GetComponent<Collider2dHandler>(), ExplosionStrength);
    }
}

public class MyClass
{
    float ExplosionStrength;
    ITransform Transform;

    public MyClass(ICollider2DHandler collider, float RepelStrength)
    {
        ExplosionStrength = RepelStrength;
        Transform = collider;
        collider.OnCollisionEnter += collider_OnCollisionEnter;
    }

    void collider_OnCollisionEnter(object sender, Collision2DEventArgs e)
    {
        if (e.Rigidbody != null)
        {
            e.Rigidbody.SetVelocity(e.Rigidbody.VelocityX * 0.5f, e.Rigidbody.VelocityY * 0.5f);
            e.Rigidbody.AddForceFromDirection(ExplosionStrength, Transform.X, Transform.Y);
        }
    }
}