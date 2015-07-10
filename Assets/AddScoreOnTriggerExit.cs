using UnityEngine;
using System.Collections;

public class AddScoreOnTriggerExit : MonoBehaviour
{
    ScoreDisplayBehaviour Score;

    void Start()
    {
        Score = GlobalComponents.Get<ScoreDisplayBehaviour>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            Score.Score += 10;
    }
}
