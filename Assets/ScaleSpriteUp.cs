//using UnityEngine;
//using System.Collections;
//using System;

//public class ScaleSpriteUp : MonoBehaviour {

//    [Range(0.001f, 0.1f)]
//    public float speed = 0.001f;

//    protected void Awake()
//    {
//        new ScaleUpSpriteRenderer(this, this, speed);
//    }
//}


//public class ScaleUpSpriteRenderer
//{
//    ITransform transform;
//    float Speed;

//    public ScaleUpSpriteRenderer(ITransform spriteRenderer, IMonoBehaviour behaviour, float speed)
//    {
//        transform = spriteRenderer;
//        behaviour.Updating += behaviour_Updating;
//        Speed = speed;
//    }

//    void behaviour_Updating(object sender, EventArgs e)
//    {
//        transform.SetScale(transform.ScaleX + Speed, transform.ScaleY + Speed);
//    }
//}