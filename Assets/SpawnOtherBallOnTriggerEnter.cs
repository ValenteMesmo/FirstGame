using UnityEngine;
using System.Collections;

public class SpawnOtherBallOnTriggerEnter : MonoBehaviour
{
    bool onCooldown;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !onCooldown && GlobalComponents.Balls.Count < 10)
        {
            var newBall = Instantiate(col.transform.root.gameObject);
            newBall.GetComponentInChildren<Rigidbody2D>().velocity = col.GetComponentInChildren<Rigidbody2D>().velocity;
            onCooldown = true;
            DelayExecution(() => { onCooldown = false; }, 2f);
        }
    }
}
