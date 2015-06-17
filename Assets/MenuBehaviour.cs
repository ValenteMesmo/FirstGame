using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {

	public void StartGameScene()
    {
        Application.LoadLevel("game");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel("game");
        }
    }
}
