using UnityEngine;
using UnitySolution.InputComponents;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ReplayGameOnTouch : MonoBehaviour
{
    public Transform LocationOfGameOverMenu;

    void Start()
    {
        if (LocationOfGameOverMenu == null)
            throw new Exception("LocationOfGameOverMenu is Required!");

        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnTouch += touches_OnTouch;
    }

    void touches_OnTouch(object sender, TransformEvevntArgs e)
    {
        Camera.main.transform.position = LocationOfGameOverMenu.position;
    }
}