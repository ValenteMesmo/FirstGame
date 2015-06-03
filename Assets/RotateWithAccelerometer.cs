using UnityEngine;
using System.Collections;

public class RotateWithAccelerometer : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, Input.acceleration.x * 2);
    }
}
