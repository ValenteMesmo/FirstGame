using UnityEngine;
using System.Collections;

public class MoveLeftOrRightOnInput : MonoBehaviour
{
    public float speed = 0.2f;
    public float minX;
    public float maxX;

    // Update is called once per frame
    void Update()
    {
        if (WrappedInput2.LeftInputPressed() && transform.position.x> minX)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        else if (WrappedInput2.RightInputPressed() && transform.position.x < maxX)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
    }
}
