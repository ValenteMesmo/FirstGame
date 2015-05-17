using UnityEngine;
using System.Collections;

public class ScoreDisplayBehaviour : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.Label(string.Format("<size=40>Score: {0}</size>", GameConstants.Score));
    }
}

public static class GameConstants
{
    public static int Score = 0;

    static GameConstants()
    {
        Score = 0;
    }
}
