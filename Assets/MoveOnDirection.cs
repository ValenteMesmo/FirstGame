using UnityEngine;
using System.Collections;

public class MoveOnDirection : MonoBehaviour
{
    public Vector3 direction = Vector3.zero;
    public float maxDistanceDelta = 10f;

    void Update()
    {
        transform.Translate(
            direction.x * Time.deltaTime,
            direction.y * Time.deltaTime,
            direction.z * Time.deltaTime);
    }
}
