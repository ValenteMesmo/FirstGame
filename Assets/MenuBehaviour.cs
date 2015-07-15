using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class MenuBehaviour : MonoBehaviour
{
    protected override void OnAwake()
    {
        PlayGamesPlatform.Activate();
    }

    public void StartGameScene()
    {
        Application.LoadLevel("game");
    }

    public void Login()
    {
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("You've successfully logged in");
            }
            else
            {
                Debug.Log("Login failed for some reason");
            }
        });
    }

    public void Logout()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel("game");
        }
    }
}
