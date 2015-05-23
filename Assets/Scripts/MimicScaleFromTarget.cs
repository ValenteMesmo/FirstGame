using UnityEngine;
using System.Collections;

public class MimicScaleFromTarget : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        transform.localScale = Target.localScale;
    }
}
