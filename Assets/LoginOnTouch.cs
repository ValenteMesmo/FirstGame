using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;
using GooglePlayGames;
using System;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class LoginOnTouch : MonoBehaviour
{
    public Transform MenuToToggle;

    void Start()
    {
        if (MenuToToggle == null)
            throw new Exception("You need to set the reference to a menu that will be enabled when Authenticated.");

        PlayGamesPlatform.Activate();

        if (Social.localUser.authenticated)
            ChangeToAuthenticatedMenu();
        else
            MenuToToggle.gameObject.SetActive(false);

        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnTouch += touches_OnTouch;
    }

    void touches_OnTouch(object sender, TransformEvevntArgs e)
    {
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(success =>
            {
                if (success)
                {
                    HighScore.Save(0);
                    ChangeToAuthenticatedMenu();
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }
        else
        {
            ChangeToAuthenticatedMenu();
        }
    }

    private void ChangeToAuthenticatedMenu()
    {
        MenuToToggle.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
