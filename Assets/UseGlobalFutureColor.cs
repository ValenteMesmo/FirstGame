using UnityEngine;
using System.Collections;

public class UseGlobalFutureColor : MonoBehaviour
{
    SpriteRenderer Renderer;
    private ColorSequence ColorSequence;

    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        ColorSequence = GlobalComponents.Get<ColorSequence>();
    }

    void Update()
    {
        if (Renderer.color != ColorSequence.FutureColor)
            Renderer.color = ColorSequence.FutureColor;
    }
}
