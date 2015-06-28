using UnityEngine;
using System.Collections;

public class EnableOnlyOnMultiBall : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    Collider2D Collider2D;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (GlobalComponents.BallCount > 1)
        {
            SpriteRenderer.enabled = true;
            Collider2D.enabled = true;
        }
        else
        {
            SpriteRenderer.enabled = false;
            Collider2D.enabled = false;
        }
    }
}
