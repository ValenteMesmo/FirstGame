using UnityEngine;
using UnitySolution.InputComponents;
using GooglePlayGames;

public class SendScoreOnTouch : MonoBehaviour
{
    void Start()
    {
        var touches = GlobalComponents.Get<DetectsTouchOnAnyCollidersInScene>();
        touches.OnTouch += inputs_OnTouch;
    }

    private void inputs_OnTouch(object sender, PointEvevntArgs e)
    {
        if (e.Transform.gameObject == gameObject)
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportScore(HighScore.Load(), "CgkItZvG5MMVEAIQAg", (bool success) =>
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
