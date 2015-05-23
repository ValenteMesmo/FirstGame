using UnityEngine;
using System.Collections;

public class BatBehaviour : MonoBehaviour
{
    public float LeftX;
    public float RightX;

    public float speedX = 0.2f;
    public float speedY = 0.1f;

    public bool movingRight = false;

    public UnityEngine.GameObject DeathPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: criar static class Tags
        if (collision.collider.tag == "Player")
        {
            if (DeathPrefab)
                Instantiate(DeathPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //TODO: criar static class Tags
        if (collision.collider.tag != "Player")
        {
            if (movingRight)
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            else
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);

        }
    }
}

public static class RandomExtensions
{
    public static bool NextBool(this System.Random random)
    {
        return random.Next(100) < 20 ? true : false;
    }
}
