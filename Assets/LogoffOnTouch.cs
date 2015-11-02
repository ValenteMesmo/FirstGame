using UnityEngine;
using GooglePlayGames;
using System;
using UnitySolution.InputComponents;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class LogoffOnTouch : MonoBehaviour
{
    void Start()
    {
        //if (MenuToToggle == null)
        //    throw new Exception("You need to set the reference to a menu that will be enabled when NOT Authenticated.");

        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStart += touches_OnTouch;
    }

    public event EventHandler OnClick;

    void touches_OnTouch(object sender, PointEventArgs e)
    {
        if (OnClick != null)
            OnClick(this, null);
        //((PlayGamesPlatform)Social.Active).SignOut();
        //if (Social.localUser.authenticated == false)
        //    ChangeToLoginMenu();
    }

    //private void ChangeToLoginMenu()
    //{
    //    MenuToToggle.gameObject.SetActive(true);
    //    gameObject.SetActive(false);
    //}
}
