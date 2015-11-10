using UnityEngine;
using System.Collections;

public class CreateObjectOnCollision : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public bool CreateOnOtherColliderPosition = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Vector2 pos;
            if (CreateOnOtherColliderPosition)
                pos = collision.collider.transform.position;
            else
                pos = transform.position;

            Instantiate(ObjectPrefab, pos, Quaternion.identity);
        }
    }
}
