using UnityEngine;
using System.Collections;
using GooglePlayGames;
using System;
using UnitySolution.InputComponents;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ShowLeaderBoardOnTouch : MonoBehaviour
{
    Animator Animator;
    void Start()
    {

        Animator = GetComponent<Animator>();
        if (Animator == null)
            throw new Exception("Animator is Required!");

        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStay += inputs_JumpButtonDown;
        touches.OnEnd += inputs_JumpButtonUp;
        touches.OnCancel += touches_OnCancel;
    }

    void touches_OnCancel(object sender, PointEventArgs e)
    {
        Animator.SetBool("pressed", false);
    }

    void inputs_JumpButtonUp(object sender, EventArgs e)
    {
        Animator.SetBool("pressed", false);


        if (Social.localUser.authenticated)
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkItZvG5MMVEAIQAg");
        }

    }

    void inputs_JumpButtonDown(object sender, EventArgs e)
    {
        Animator.SetBool("pressed", true);
    }
}
