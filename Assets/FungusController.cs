using UnityEngine;
using System.Collections;

public class FungusController : MonoBehaviour
{
    public BaseCollider2DHandler LeftCollider;
    public BaseCollider2DHandler MiddleCollider;
    public BaseCollider2DHandler RightCollider;

    private IAnimatorHandler LeftAnimator;
    private IAnimatorHandler RightAnimator;
    private IAnimatorHandler MiddleAnimator;

    protected bool leftDown;
    protected bool middleDown;
    protected bool rightDown;

    private const string DIE = "die";
    private const string REVIVE = "revive";

    private ScoreDisplayBehaviour ScoreDisplayBehaviour;

    protected override void OnAwake()
    {
        base.OnAwake();

        LeftAnimator = LeftCollider.gameObject.GetComponent<AnimatorHandler>();
        MiddleAnimator = MiddleCollider.gameObject.GetComponent<AnimatorHandler>();
        RightAnimator = RightCollider.gameObject.GetComponent<AnimatorHandler>();

        LeftCollider.OnCollisionEnter += Left_OnCollisionEnter;
        MiddleCollider.OnCollisionEnter += Middle_OnCollisionEnter;
        RightCollider.OnCollisionEnter += Right_OnCollisionEnter;

        ScoreDisplayBehaviour = GlobalComponents.GetGlobalComponent<ScoreDisplayBehaviour>();
    }

    void Middle_OnCollisionEnter(object sender, Collision2DEventArgs e)
    {
        if (e.Tag == "Player")
        {
            middleDown = true;
            MiddleAnimator.SetTrigger(DIE);
            MiddleCollider.DisableCollider2D();
            ResetIfObjectiveComplete();
        }
    }

    void Left_OnCollisionEnter(object sender, Collision2DEventArgs e)
    {
        if (e.Tag == "Player")
        {
            leftDown = true;
            LeftAnimator.SetTrigger(DIE);
            LeftCollider.DisableCollider2D();
            ResetIfObjectiveComplete();
        }
    }

    void Right_OnCollisionEnter(object sender, Collision2DEventArgs e)
    {
        if (e.Tag == "Player")
        {
            rightDown = true;
            RightAnimator.SetTrigger(DIE);
            RightCollider.DisableCollider2D();
            ResetIfObjectiveComplete();
        }
    }

    void ResetIfObjectiveComplete()
    {
        ScoreDisplayBehaviour.Score += 10;
        if (leftDown && middleDown && rightDown)
        {
            ScoreDisplayBehaviour.Score += 500;
            DelayExecution(() =>
            {
                leftDown = false;
                middleDown = false;
                rightDown = false;
                MiddleAnimator.SetTrigger(REVIVE);
                LeftAnimator.SetTrigger(REVIVE);
                RightAnimator.SetTrigger(REVIVE);
                LeftCollider.EnableCollider2D();
                MiddleCollider.EnableCollider2D();
                RightCollider.EnableCollider2D();
            }, 3f);
        }
    }
}
