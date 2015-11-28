using UnityEngine;
using System.Collections;

public class HidePlayersOnTriggerEnter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponentInChildren<TrailRenderer>().enabled = false;
            col.transform.parent.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponentInChildren<TrailRenderer>().enabled = true;
            col.transform.parent.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }

}
