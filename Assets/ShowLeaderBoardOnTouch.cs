using UnityEngine;
using System.Collections;
using GooglePlayGames;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ShowLeaderBoardOnTouch : MonoBehaviour 
{
    void Start()
    {
        var touches = GetComponent<DetectTouchOnThisGameObject>();
        touches.OnStart += touches_OnTouch;
    }

    void touches_OnTouch(object sender, UnitySolution.InputComponents.PointEventArgs e)
    {
        if (Social.localUser.authenticated)
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkItZvG5MMVEAIQAg");
        }
    }
}
