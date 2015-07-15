using UnityEngine;
using System.Collections;
using System;

public class GameOverBehaviour : MonoBehaviour
{
    public Transform LocationOfGameOverMenu;

    void Start()
    {
        if (LocationOfGameOverMenu == null)
            throw new Exception("LocationOfGameOverMenu is Required!");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (GlobalComponents.Balls.Count <= 1)
        {
            Camera.main.transform.position = LocationOfGameOverMenu.position;
        }
        Destroy(col.transform.root.gameObject);
    }
}
