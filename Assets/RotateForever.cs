using UnityEngine;
using System.Collections;

public class RotateForever : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
