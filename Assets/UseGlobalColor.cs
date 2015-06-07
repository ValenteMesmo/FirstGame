using UnityEngine;
using System.Collections;

public class UseGlobalColor : MonoBehaviour
{
    SpriteRenderer Renderer;

    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Renderer.color != GameInfo.CurrentColor)
            Renderer.color = GameInfo.CurrentColor;
    }
}
