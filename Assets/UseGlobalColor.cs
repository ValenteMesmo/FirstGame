using UnityEngine;
using System.Collections;

public class UseGlobalColor : MonoBehaviour
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
        if (Renderer.color != ColorSequence.CurrentColor)
            Renderer.color = ColorSequence.CurrentColor;
    }
}
