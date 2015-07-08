using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AddRigidBodyToGlobalComponents : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        GlobalComponents.Balls.Add(Rigidbody2D);
    }

    void OnDestroy()
    {
        GlobalComponents.Balls.Remove(Rigidbody2D);
    }
}
