using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;

public class ReplayGameOnTouch : MonoBehaviour {

    void Start()
    {
        var touches = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        touches.OnTouch += inputs_OnTouch;
        touches.OffTouch += inputs_OffTouch;
    }

    private void inputs_OffTouch(object sender, TransformEvevntArgs e)
    {
    }

    private void inputs_OnTouch(object sender, PointEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
        {
            Application.LoadLevel("menu");
        }
    }
}
