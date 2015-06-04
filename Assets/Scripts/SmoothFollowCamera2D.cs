using UnityEngine;
using System.Collections;

public class SmoothFollowCamera2D : MonoBehaviour
{
    public Transform target;
    //private Vector3 velocity = Vector3.zero;

    public float difference = 14f;

    public float minY = 22.5f;

    //public float dampTime = 0.15f;
    public float t = 0.15f;

    private Vector3 targetPosition;

    protected override void OnAwake()
    {
        targetPosition = transform.position;
        base.OnAwake();
    }

    void LateUpdate()
    {
        Vector3 point = Camera.main.WorldToViewportPoint(target.position);
        Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));

        if ((delta.y < -difference || delta.y > difference))
            targetPosition = target.position;


        var newPosition = transform.position + t * (targetPosition - transform.position).normalized;
        if (newPosition.y < minY)
            newPosition.y = minY;

        transform.position = new Vector3(transform.position.x,newPosition.y,transform.position.z);



        //if (target)
        //{
        //    Vector3 targetPosition = transform.position;

        //    var heightDifference = target.position.y - transform.position.y;

        //    if ((heightDifference < -difference || heightDifference > difference))
        //    {
        //        if (target.position.y > minY)
        //            targetPosition.y = target.position.y;
        //        else
        //            targetPosition.y = minY;
        //    }

        //    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //}
    }
}
