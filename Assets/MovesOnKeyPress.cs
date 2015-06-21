using UnityEngine;
using System.Collections;

public class MovesOnKeyPress : MonoBehaviour {

    public Transform TargetPosition;
    Vector3 OriginalPosition;
    public float maxDistPerSecond = 1f;
    public float maxDistPerSecondGoingBack = 10f;

    protected override void OnAwake()
    {
        OriginalPosition = transform.position;
        base.OnAwake();
    }

    void Update()
    {
        if (!GlobalComponents.FlippersEnabled)
        {
            if (WrappedInput2.GetLeftInputPressed() || WrappedInput2.GetRightInputPressed())
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetPosition.position, maxDistPerSecond * Time.deltaTime);
            }
            else if (transform.position != OriginalPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, OriginalPosition, maxDistPerSecondGoingBack * Time.deltaTime);
            } 
        }
        else  if (transform.position != OriginalPosition)
            transform.position = Vector3.MoveTowards(transform.position, OriginalPosition, maxDistPerSecondGoingBack * Time.deltaTime);
    }
}
