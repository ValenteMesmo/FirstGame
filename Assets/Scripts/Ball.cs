using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            GameConstants.Score = 0;
            Application.LoadLevel("menu");
        }
    }
}
