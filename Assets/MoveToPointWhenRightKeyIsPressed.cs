using UnityEngine;
using System.Collections;

public class MoveToPointWhenRightKeyIsPressed : MonoBehaviour
{
    public Vector2 TargetPosition;
    private Vector2 OriginalPosition;

    bool pressed;

    void Start()
    {
        OriginalPosition = transform.position;
        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.RightButtonUp += inputs_RightButtonUp;
        inputs.RightButtonDown += inputs_RightButtonDown;
    }

    void inputs_RightButtonDown(object sender, System.EventArgs e)
    {
        pressed = true;
    }

    void inputs_RightButtonUp(object sender, System.EventArgs e)
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
