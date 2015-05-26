using UnityEngine;
using System.Collections;

public class SmoothFollowCamera2D : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.15f;

    public float difference = 4f;

    public float minY = 0f;

    void Update()
    {
        if (target)
        {
            Vector3 targetPosition = transform.position;

            var heightDifference = target.position.y - transform.position.y;

            if ((heightDifference < -difference || heightDifference > difference))
            {
                if (target.position.y > minY)
                    targetPosition.y = target.position.y;
                else
                    targetPosition.y = minY;
            }

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
