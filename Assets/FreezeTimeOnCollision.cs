using UnityEngine;
using System.Collections;

public class FreezeTimeOnCollision : MonoBehaviour
{
    TimeScale timeScale;
    float milliseconds = 30;

    void Start()
    {
        timeScale = GlobalComponents.Get<TimeScale>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            timeScale.Freeze(milliseconds);
        }
    }
}
