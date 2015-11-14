using UnityEngine;
using System.Collections;

public class CreateObjectOnCollision : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public bool CreateOnOtherColliderPosition = true;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.relativeVelocity.magnitude >= 3f)
        //if (collision.collider.tag == "Player")
        {
            Vector2 pos;
            if (CreateOnOtherColliderPosition)
                pos = collision.contacts[0].point;
            else
                pos = transform.position;

            Instantiate(ObjectPrefab, pos, Quaternion.identity);

        }
    }
}
