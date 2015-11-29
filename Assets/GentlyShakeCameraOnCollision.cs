using UnityEngine;
using System.Collections;

public class GentlyShakeCameraOnCollision : MonoBehaviour
{
    public Animator CameraAnimator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Vibrate")
        {
            CameraAnimator.SetTrigger("easyShake");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Vibrate")
        {
            CameraAnimator.SetTrigger("easyShake");
        }
    }

}
