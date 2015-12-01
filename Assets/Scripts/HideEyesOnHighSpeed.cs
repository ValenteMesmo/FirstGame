using UnityEngine;
using System.Collections;

public class HideEyesOnHighSpeed : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D Rigidbody2D;

    public float speedToCHangeAnimation = 8f;

    void Awake()
    {
        SpriteRenderer = transform.Find("Player Face").GetComponent<SpriteRenderer>();
        Rigidbody2D = transform.Find("Player Bone").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SpriteRenderer.enabled = !IsMovingOnHighVelocity();
    }

    private bool IsMovingOnHighVelocity()
    {
        return Rigidbody2D.velocity.x < -speedToCHangeAnimation ||
            Rigidbody2D.velocity.y < -speedToCHangeAnimation ||
            Rigidbody2D.velocity.x > speedToCHangeAnimation ||
            Rigidbody2D.velocity.y > speedToCHangeAnimation;
    }
}
