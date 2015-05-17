using UnityEngine;
using System.Collections;

public class ChangeColorOnCollision : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    public Color Color = Color.red;
    public float Duration = 0.3f;

    private float RestoreColorTime = 0f;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.time >= RestoreColorTime)
            SpriteRenderer.color = GameInfo.CurrentColor;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        SpriteRenderer.color = Color;
        RestoreColorTime = Time.time + Duration;
    }
}
