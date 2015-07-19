using GooglePlayGames;
using UnityEngine;

public class GameOverBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.transform.root.gameObject);

        if (GlobalComponents.Balls.Count <= 1)
        {
            var currentScore = GlobalComponents.Get<ScoreDisplayBehaviour>().Score;
            //var lastScore = SavedInfo.GetHighScore();

            //if (currentScore > lastScore)
            //{
                if (Social.localUser.authenticated)
                {
                    Social.ReportScore(/*HighScore.Load()*/currentScore, "CgkItZvG5MMVEAIQAg", (bool success) =>
                    {
                        //if(success)
                        //    HighScore.Save(currentScore);

                        Application.LoadLevel(Application.loadedLevel);
                    });
                }
                else
                    Application.LoadLevel(Application.loadedLevel);
            //}
            //else
            //    Application.LoadLevel(Application.loadedLevel);
        }
    }
}

public class SavedInfo
{
    public static void SetHighScore(int value)
    {
        PlayerPrefs.SetInt("HighScore", value);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public static void SetIsAuthenticated(bool value)
    {
        if (value)
            PlayerPrefs.SetInt("Authenticated", 1);
        else
            PlayerPrefs.SetInt("Authenticated", 0);
    }

    public static bool GetIsAuthenticated()
    {
        return PlayerPrefs.GetInt("Authenticated") > 0;
    }
}