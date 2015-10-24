using System;
using UnityEngine;

public class GameScreenController: MonoBehaviour
{
    public Transform MainTableCameraPosition;
    private bool isOnMainMenu;

    void Start()
    {
        if (MainTableCameraPosition == null)
            throw new Exception("LocationOfGameOverMenu is Required!");
        isOnMainMenu = true;
    }

    public void GoToMainTablePosition()
    {
        Camera.main.transform.position = MainTableCameraPosition.position;
        isOnMainMenu = false;
    }

    public bool IsOnMainMenu()
    {
        return isOnMainMenu;
    }
}