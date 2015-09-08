//using System;
//using UnityEngine;

//[RequireComponent(typeof(SpriteRendererHandler))]
//public class FadeOut : MonoBehaviour
//{
//    [Range(0.001f, 0.1f)]
//    public float speed = 0.05f;

//    protected void Awake()
//    {
//        new FadeOutSpriteRenderer(GetComponent<SpriteRendererHandler>(), this, speed);
//    }


//}

//public class FadeOutSpriteRenderer
//{
//    ISpriteRendererHandler SpriteRenderer;
//    float Speed;

//    public FadeOutSpriteRenderer(ISpriteRendererHandler spriteRenderer, IMonoBehaviour behaviour, float speed)
//    {
//        SpriteRenderer = spriteRenderer;
//        behaviour.Updating += behaviour_Updating;
//        Speed = speed;
//    }

//    void behaviour_Updating(object sender, EventArgs e)
//    {
//        var newAlpha = SpriteRenderer.Alpha - Speed;
//        if (newAlpha < 0)
//        {
//            SpriteRenderer.SetColor(SpriteRenderer.Red, SpriteRenderer.Green, SpriteRenderer.Blue, 0f);
//        }
//        else
//        {
//            SpriteRenderer.SetColor(SpriteRenderer.Red, SpriteRenderer.Green, SpriteRenderer.Blue, newAlpha);
//        }
//    }
//}
