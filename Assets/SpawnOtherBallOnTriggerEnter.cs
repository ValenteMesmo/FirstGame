using UnityEngine;
using System.Collections;

public class SpawnOtherBallOnTriggerEnter : MonoBehaviour
{
    bool onCooldown;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !onCooldown && GlobalComponents.Balls.Count < 10)
        {
            Instantiate(col.transform.root.gameObject);
            onCooldown = true;
            DelayExecution(() => { onCooldown = false; }, 2f);
        }
    }
}
