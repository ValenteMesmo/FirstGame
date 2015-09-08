using UnityEngine;
using System.Collections;

public class ChangeColorOnTriggerStay : MonoBehaviour
{
    private Color OriginalColor;
    public Color NewColor;

    SpriteRenderer SpriteRendererHandler;
    protected void Start()
    {
        SpriteRendererHandler = GetComponent<SpriteRenderer>();
        OriginalColor = SpriteRendererHandler.color;
    }

    void OnTriggerExit2D(Collider2D e)
    {
        if (e.tag == "Player")
            SpriteRendererHandler.color = OriginalColor;
    }

    void OnTriggerEnter2D(Collider2D e)
    {
        if (e.tag == "Player")
            SpriteRendererHandler.color = NewColor;
    }
}
