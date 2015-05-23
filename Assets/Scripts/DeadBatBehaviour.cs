using UnityEngine;

public class DeadBatBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
