using UnityEngine;
using System.Collections;

public class RightFlipper : BaseFlipper
{
    protected override void OnInit()
    {
        speed = -speed;
        UpperAngleLimit = -UpperAngleLimit;
    }

    protected override bool ConditionToMoveUp()
    {
        return rb2D.rotation > UpperAngleLimit;
    }

    protected override bool ConditionToMoveDown()
    {
        return rb2D.rotation < LowerAngleLimit;
    }

    protected override bool CheckButtomPressed()
    {
        return WrappedInput2.RightInputPressed();
    }
}
