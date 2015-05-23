using UnityEngine;
using System.Collections;

public class SpawnBatOnCollision : MonoBehaviour
{
    public UnityEngine.GameObject Prefab;

    public Vector2 SpawnPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: criar static class Tags
        if (collision.collider.tag == "Player")
            Instantiate(Prefab, SpawnPoint, Quaternion.identity);
    }
}
