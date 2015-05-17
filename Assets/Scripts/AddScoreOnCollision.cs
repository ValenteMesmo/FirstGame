using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class AddScoreOnCollision : MonoBehaviour
{
    public int Amount = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            GameConstants.Score += Amount;
    }
}