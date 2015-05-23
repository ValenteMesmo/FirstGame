using UnityEngine;
using System.Collections;

public class TimeScale : MonoBehaviour
{
    public float Value = 1f;

    void Start()
    {
        Time.timeScale = Value;
    }
}
