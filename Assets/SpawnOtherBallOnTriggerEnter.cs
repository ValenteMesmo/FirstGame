using UnityEngine;
using System.Collections;

public class SpawnOtherBallOnTriggerEnter : MonoBehaviour {
    bool onCooldown;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !onCooldown)
        {
            Instantiate(col.transform.root.gameObject);
            GlobalComponents.BallCount++;
            onCooldown = true;
            DelayExecution(() => { onCooldown = false; }, 2f);
        }
    }
}
