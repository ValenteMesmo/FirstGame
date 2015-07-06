using UnityEngine;
using System.Collections;

public class WarpWhenXLowerThenValue : MonoBehaviour
{
    public float XValue = 0f;
    public float WarpDistance = 50f;

    void Start()
    {
        XValue = Camera.main.ScreenToWorldPoint(new Vector2(XValue,0)).x;        
    }

    void Update()
    {
        if (transform.position.x < XValue)
            transform.Translate(WarpDistance, 0, 0);
    }
}
