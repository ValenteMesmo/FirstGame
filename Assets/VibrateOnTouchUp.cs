using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class VibrateOnTouchUp : MonoBehaviour {

    public long milliseconds = 100;
    VibrationHandler VibrationHandler;

    void Start()
    {
        VibrationHandler = new VibrationHandler(this);
        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnEnd += touches_OffTouch;
    }

    void touches_OffTouch(object sender, TransformEvevntArgs e)
    {
        VibrationHandler.Vibrate(milliseconds);
    }
}
