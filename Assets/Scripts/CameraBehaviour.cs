using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
    //public Transform TargetToFollow;
    //public float MinZoom = 4f;
    //public float MaxZoom = 24f;

    //public float MaximunValueForY = 24f;
    //public float MinimunValueForY = 10f;

    void Start()
    {
        
        
        //transform.position = new Vector3(transform.transform.position.x, MinimunValueForY, transform.position.z);

    }

    //private void NewMethod(float velocity)
    //{
    //    if (velocity > MinZoom && velocity < MaxZoom)
    //        Camera.main.orthographicSize = velocity;
    //    else if (velocity < MinZoom)
    //        Camera.main.orthographicSize = MinZoom;
    //    else if (velocity > MaxZoom)
    //        Camera.main.orthographicSize = MaxZoom;
    //}

    void Update()
    {
        //var nextY = TargetToFollow.position.y;
        //if (nextY > MinimunValueForY && nextY < MaximunValueForY)
        //    transform.position = new Vector3(transform.transform.position.x, TargetToFollow.transform.position.y, transform.position.z);
    }
}

