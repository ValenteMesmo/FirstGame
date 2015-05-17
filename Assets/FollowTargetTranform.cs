using UnityEngine;
using System.Collections;

public class FollowTargetTranform : MonoBehaviour
{
    public Transform Target;
    void Update()
    {
        transform.position = Target.position;
    }
}
