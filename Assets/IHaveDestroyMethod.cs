using UnityEngine;
using System.Collections;

public class IHaveDestroyMethod : MonoBehaviour {

	public void DestroyItSelf()
    {
        Destroy(transform.gameObject);
    }
}
