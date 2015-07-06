using UnityEngine;
using System.Collections;
using System;

public class ChangeCameraOnTriggerEnter : MonoBehaviour
{
    public Transform TargetPosition;
    public Transform CameraPosition;
    public float CameraZoom = 13f;

    void OnTriggerEnter2D(Collider2D col)
    {
        Camera.main.transform.position = new Vector3(CameraPosition.position.x, CameraPosition.position.y, Camera.main.transform.position.z);
        Camera.main.orthographicSize = CameraZoom;

        DisableTrailRendererTemporarily(col);

        col.transform.position = new Vector3(TargetPosition.position.x, TargetPosition.position.y,col.transform.position.z);       
    }

    private void DisableTrailRendererTemporarily(Collider2D col)
    {
        var trail = col.GetComponentInChildren<TrailRenderer>();
        if (trail != null)
        {
            trail.enabled = false;
            DelayExecution(() => trail.enabled = true, 0.5f);
        }
    }
}