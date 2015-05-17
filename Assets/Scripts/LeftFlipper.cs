using UnityEngine;

public class LeftFlipper : BaseFlipper
{
    protected override bool ConditionToMoveUp()
    {
        return rb2D.rotation < UpperAngleLimit;
    }

    protected override bool ConditionToMoveDown()
    {
        return rb2D.rotation > LowerAngleLimit;
    }

    protected override bool CheckButtomPressed()
    {
        return WrappedInput2.LeftInputPressed();
    }
}