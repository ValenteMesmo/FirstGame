using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FungusController : MonoBehaviour
{
    public class FungusInstance
    {
        public bool IsDown;
        public Animator Animator;
        public FireEventOnCollision Collider;

        public FungusInstance(FireEventOnCollision collider)
        {
            Animator = collider.gameObject.GetComponent<Animator>();
            Collider = collider;
            Collider.Enter += collider_OnCollisionEnter;
        }

        void collider_OnCollisionEnter(object sender, TriggerEventArgs e)
        {
            if (e.Collider.tag == "Player")
            {
                IsDown = true;
                Animator.SetTrigger(DIE);
            }
        }
    }

    public FireEventOnCollision[] Colliders;
    private IList<FungusInstance> fungusCollection;

    private const string DIE = "die";
    private const string REVIVE = "revive";

    private ScoreDisplayBehaviour ScoreDisplayBehaviour;

    public event EventHandler FungusDestroyed;

    protected void Awake()
    {
        fungusCollection = new List<FungusInstance>();

        foreach (var item in Colliders)
        {
            fungusCollection.Add(new FungusInstance(item));
            item.Enter += item_OnCollisionEnter;
        }

        ScoreDisplayBehaviour = GlobalComponents.Get<ScoreDisplayBehaviour>();
    }

    void item_OnCollisionEnter(object sender, TriggerEventArgs e)
    {
        if (e.Collider.tag == "Player")
        {
            ResetIfObjectiveComplete();
        }
    }

    void ResetIfObjectiveComplete()
    {
        ScoreDisplayBehaviour.AddScore(10);

        bool allDown = true;

        foreach (var item in fungusCollection)
        {
            allDown = allDown && item.IsDown;
        }

        if (allDown)
        {
            if (FungusDestroyed != null)
                FungusDestroyed(this, null);

            ScoreDisplayBehaviour.AddScore(500);
            DelayExecution(() =>
            {
                foreach (var item in fungusCollection)
                {
                    item.IsDown = false;
                    item.Animator.SetTrigger(REVIVE);
                }
            }, 3f);
        }
    }
}
