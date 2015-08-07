using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FungusController : MonoBehaviour
{
    public class FungusInstance
    {
        public bool IsDown;
        public IAnimatorHandler Animator;
        public BaseCollider2DHandler Collider;

        public FungusInstance(BaseCollider2DHandler collider)
        {
            Animator = collider.gameObject.GetComponent<AnimatorHandler>();
            Collider = collider;
            Collider.OnCollisionEnter += collider_OnCollisionEnter;
        }

        void collider_OnCollisionEnter(object sender, Collision2DEventArgs e)
        {
            if (e.Tag == "Player")
            {
                IsDown = true;
                Animator.SetTrigger(DIE);
                Collider.DisableCollider2D();                
            }
        }
    }

    public BaseCollider2DHandler[] Colliders;
    private IList<FungusInstance> fungusCollection; 

    private const string DIE = "die";
    private const string REVIVE = "revive";

    private ScoreDisplayBehaviour ScoreDisplayBehaviour;

    public event EventHandler FungusDestroyed;

    protected override void OnAwake()
    {
        base.OnAwake();

        fungusCollection = new List<FungusInstance>();

        foreach (var item in Colliders)
        {
            fungusCollection.Add(new FungusInstance(item));
            item.OnCollisionEnter += item_OnCollisionEnter;
        }

        ScoreDisplayBehaviour = GlobalComponents.Get<ScoreDisplayBehaviour>();
    }

    void item_OnCollisionEnter(object sender, Collision2DEventArgs e)
    {
        if (e.Tag == "Player")
        {
            ResetIfObjectiveComplete();
        }
    }

    void ResetIfObjectiveComplete()
    {
        ScoreDisplayBehaviour.Score += 10;

        bool allDown = true;

        foreach (var item in fungusCollection)
        {
            allDown = allDown && item.IsDown;
        }

        if (allDown)
        {
            if (FungusDestroyed != null)
                FungusDestroyed(this, null);

            ScoreDisplayBehaviour.Score += 500;
            DelayExecution(() =>
            {
                foreach (var item in fungusCollection)
                {
                    item.IsDown = false;
                    item.Animator.SetTrigger(REVIVE);
                    item.Collider.EnableCollider2D();
                }
            }, 3f);
        }
    }
}
