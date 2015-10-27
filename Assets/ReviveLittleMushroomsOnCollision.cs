using UnityEngine;
using System.Collections;
using System;

public class ReviveLittleMushroomsOnCollision : MonoBehaviour
{

    public FungusController controller;

    void Start()
    {
        if (controller == null)
            throw new NullReferenceException("ReviveLittleMushroomsOnCollision");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        controller.Revive();
    }
}
