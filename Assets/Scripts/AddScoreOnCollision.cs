using UnityEngine;
using System.Collections;
using System;

public class AddScoreOnCollision : MonoBehaviour
{
    public int Amount = 10;
    private ScoreDisplayBehaviour ScoreDisplayBehaviour;

    void Start()
    {
        if (GetComponent<Collider2D>() == null)
            throw new NullReferenceException("Collider2D is required for 'RepelColliders'");

        ScoreDisplayBehaviour = GlobalComponents.Get<ScoreDisplayBehaviour>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            ScoreDisplayBehaviour.AddScore(Amount);
    }
}