using UnityEngine;
using System.Collections;

public class HideEyesOnHighSpeed : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Rigidbody2D;

    public float speedToCHangeAnimation = 8f;
    Color oldCOlor;
    Color invisible = new Color(0, 0, 0, 0);
    void Awake()
    {
        oldCOlor = SpriteRenderer.color;
    }

    void Update()
    {
        if (IsMovingOnHighVelocity())
            SpriteRenderer.color = invisible;
        else
            SpriteRenderer.color = oldCOlor;
    }

    private bool IsMovingOnHighVelocity()
    {
        return Rigidbody2D.velocity.x < -speedToCHangeAnimation ||
            Rigidbody2D.velocity.y < -speedToCHangeAnimation ||
            Rigidbody2D.velocity.x > speedToCHangeAnimation ||
            Rigidbody2D.velocity.y > speedToCHangeAnimation;
    }
}
