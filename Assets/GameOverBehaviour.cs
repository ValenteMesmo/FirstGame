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
            var lastScore = HighScore.Load();

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

public class HighScore
{
    public static void Save(int value)
    {
        PlayerPrefs.SetInt("HighScore", value);
    }

    public static int Load()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}