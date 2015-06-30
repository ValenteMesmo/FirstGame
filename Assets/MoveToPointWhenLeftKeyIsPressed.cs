using UnityEngine;
using System.Collections;

public class MoveToPointWhenLeftKeyIsPressed : MonoBehaviour
{
    public Vector2 TargetPosition;
    private Vector2 OriginalPosition;

    bool pressed;

    void Start()
    {
        OriginalPosition = transform.position;
        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.LeftButtonUp += inputs_LeftButtonUp;
        inputs.LeftButtonDown += inputs_LeftButtonDown;
    }

    void inputs_LeftButtonDown(object sender, System.EventArgs e)
    {
        pressed = true;
    }

    void inputs_LeftButtonUp(object sender, System.EventArgs e)
    {
        pressed = false;
    }

    void Update()
    {
        if (pressed)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, 0.5f);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, OriginalPosition, 0.5f);
        }
    }
}
