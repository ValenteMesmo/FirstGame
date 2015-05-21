using UnityEngine;
using System.Collections;

public class DestructibleBoxBehavior : MonoBehaviour {

    protected override void OnAwake()
    {
        new DestructibleBox(this, this);
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
            Debug.Log(e.Tag);

            if (e.Tag == "Player")
            {
                //Animator.SetBool("Hit", true);
                Animator.PlayAnimation("boxDestroyed");
                Collider.DisableCollider2D();
            }
        }
    }
}
