using System;
using UnitySolution.InputComponents;

public class DetectTouchOnThisGameObject : MonoBehaviour
{
    void Start()
    {
        var touches = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        touches.OnTouch += inputs_OnTouch;
        touches.OffTouch += inputs_OffTouch;
    }

    public event EventHandler<TransformEvevntArgs> OnTouch;
    public event EventHandler<TransformEvevntArgs> OffTouch;

    private void inputs_OffTouch(object sender, TransformEvevntArgs e)
    {
        if (OffTouch != null && e.Transform.gameObject == gameObject)
            OffTouch(this, e);
    }

    private void inputs_OnTouch(object sender, PointEvevntArgs e)
    {
        if (OnTouch != null && e.Transform.gameObject == gameObject)
            OnTouch(this, e);
    }
}
