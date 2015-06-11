using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private ScoreDisplayBehaviour ScoreDisplayBehaviour;

    void Start()
    {
        ScoreDisplayBehaviour = GlobalComponents.Get<ScoreDisplayBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            ScoreDisplayBehaviour.Score = 0;
            Application.LoadLevel("menu");
        }
    }
}
