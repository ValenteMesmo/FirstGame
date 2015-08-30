using UnityEngine;
using System.Collections;

public class CreateObjectOnCollision : MonoBehaviour
{

    public GameObject ObjectPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            Instantiate(ObjectPrefab, transform.position,  Quaternion.identity);

    }

}
