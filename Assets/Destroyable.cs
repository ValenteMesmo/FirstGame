using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour
{

    public void DestroyItSelf()
    {
        Destroy(transform.gameObject);
        //gameob
    }
}
