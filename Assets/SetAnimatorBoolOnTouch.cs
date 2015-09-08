using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
[RequireComponent(typeof(Animator))]
public class SetAnimatorBoolOnTouch : MonoBehaviour
{
    public string parameterName = "down";

    Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
        var touch = GetComponent<DetectTouchOnThisGameObject>();
        touch.OnStart += touch_OnTouch;
        touch.OnEnd += touch_OffTouch;
    }

    void touch_OffTouch(object sender, UnitySolution.InputComponents.TransformEvevntArgs e)
    {
        Animator.SetBool(parameterName, false);
    }

    void touch_OnTouch(object sender, UnitySolution.InputComponents.TransformEvevntArgs e)
    {
        Animator.SetBool(parameterName, true);
    }

}
