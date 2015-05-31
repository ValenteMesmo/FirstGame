﻿using UnityEngine;
using System.Collections;

public class DestructibleBoxBehavior : MonoBehaviour {

    protected override void OnAwake()
    {
        new DestructibleBox(this,  GetComponent<Animator>());
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    public class DestructibleBox
    {
        IAnimator Animator;
        IBoxCollider2D Collider;

        public DestructibleBox(IBoxCollider2D collider, IAnimator animator)
        {
            collider.OnCollisionEnter += collider_OnCollisionEnter;
            Animator = animator;
            Collider = collider;
        }

        void collider_OnCollisionEnter(object sender, Collision2DEventArgs e)
        {
            if (e.Tag == "Player")
            {
                Animator.PlayAnimation("boxDestroyed");
                Collider.DisableCollider2D();
            }
        }
    }
}
