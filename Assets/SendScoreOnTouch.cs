using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;
using GooglePlayGames;

public class SendScoreOnTouch : MonoBehaviour
{

    void Start()
    {
        var touches = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        touches.OnTouch += inputs_OnTouch;
        touches.OffTouch += inputs_OffTouch;
    }

    private void inputs_OffTouch(object sender, TransformEvevntArgs e)
    {
    }

    private void inputs_OnTouch(object sender, PointEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportScore(GlobalComponents.Get<ScoreDisplayBehaviour>().Score, "CgkItZvG5MMVEAIQAg", (bool success) =>
                {
                    if (success)
                    {
                        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkItZvG5MMVEAIQAg");
                    }
                    else
                    {
                        Debug.Log("OPS!");
                    }
                });
            }
        }
    }
}
