using UnityEngine;
using System.Collections;

public class DeleteRootOnTriggerEnter : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            Destroy(transform.root.gameObject);
    }
}
