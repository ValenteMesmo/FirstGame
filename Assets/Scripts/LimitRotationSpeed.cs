using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class LimitRotationSpeed : MonoBehaviour
{
    public float MaximunRotationSpeed = 20f;
    private Rigidbody2D Body;

    void Start()
    {
        Application.targetFrameRate = 60;
        Body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log(Body.angularVelocity.ToString());
        if (Body.angularVelocity > MaximunRotationSpeed)
        {
            Body.angularVelocity = MaximunRotationSpeed;
        }
        else if (Body.angularVelocity < -MaximunRotationSpeed)
        {
            Body.angularVelocity = -MaximunRotationSpeed;
        }
    }
}
