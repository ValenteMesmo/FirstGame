using UnityEngine;
using System.Collections;

public class DestructibleBoxBehavior : MonoBehaviour
{
    protected override void OnAwake()
    {
        new DestructibleBox(GetComponent<BoxCollider2DHandler>(), GetComponent<AnimatorHandler>());
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    public class DestructibleBox
    {
        IAnimatorHandler Animator;
        IBoxCollider2DHandler Collider;

        public DestructibleBox(IBoxCollider2DHandler collider, IAnimatorHandler animator)
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
