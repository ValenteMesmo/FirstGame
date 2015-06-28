using UnityEngine;
using System.Collections;

public class GameOverBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (GlobalComponents.BallCount <= 1)
        {
            Application.LoadLevel("menu");
        }
        else
        {
            Destroy(col.transform.root.gameObject);
            GlobalComponents.BallCount--;
        }
    }
}
