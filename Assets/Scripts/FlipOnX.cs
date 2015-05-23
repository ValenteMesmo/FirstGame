using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FlipOnX : MonoBehaviour
{
    Rigidbody2D Body;
    public float folga = 3f;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log(Body.velocity.x.ToString());
        if ( ShouldChangeToRight() || ShouldChangeToLeft())
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private bool ShouldChangeToLeft()
    {
        return Body.velocity.x < -folga && transform.localScale.x > 0;
    }

    private bool ShouldChangeToRight()
    {
        return Body.velocity.x > folga && transform.localScale.x < 0;
    }
}
