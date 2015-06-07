using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2DHandler))]
[RequireComponent(typeof(AnimatorHandler))]
public class KinghtBehaviour : MonoBehaviour
{
    //assuming value 3 on animator too
    private int hitPoints = 1;//3;
    CircleCollider2DHandler Collider;
    AnimatorHandler animator;

    protected override void OnAwake()
    {
        base.OnAwake();
        Collider = GetComponent<CircleCollider2DHandler>();
        animator = GetComponent<AnimatorHandler>();
        
        Collider.OnCollisionEnter += loseOneHitPoints;
    }

    void loseOneHitPoints(object sender, Collision2DEventArgs e)
    {
        animator.SetInt("hitPoints", --hitPoints);
        if (hitPoints <= 0)
        {
            Collider.OnCollisionEnter -= loseOneHitPoints;
            Collider.OnCollisionEnter += die;
            Updating += KinghtBehaviour_Updating;
        }
    }

    public Vector3 v3TargetPosition = Vector3.zero;
    float maxDistPerSecond = 1;
    void KinghtBehaviour_Updating(object sender, System.EventArgs e)
    {
        transform.position = Vector3.MoveTowards(transform.position, v3TargetPosition, maxDistPerSecond * Time.deltaTime);
        if (transform.position == v3TargetPosition)
            Debug.Log("chegou!");
    }

    void die(object sender, Collision2DEventArgs e)
    {
        Destroy(gameObject);
    }
}
