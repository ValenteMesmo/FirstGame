using UnityEngine;
using System.Collections;

public class ScoreDisplayBehaviour : MonoBehaviour
{
    private int Score = 0;

    private Rect scoreDisplayArea;
    private string scoreTextFormat;

    void Start()
    {
        
        scoreDisplayArea = new Rect(0, Screen.height - Screen.height * 0.1f, Screen.width, Screen.height);
        scoreTextFormat = "<size=" + Screen.height * 0.05f + ">{0}</size>";
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public int  GetScore()
    {
        return Score;
    }

    public void ClearScore()
    {
        Score = 0;
    }

    //void OnApplicationFocus() { Debug.Log("OnApplicationFocus"); }
    //void OnApplicationPause() { Debug.Log("OnApplicationPause"); }
    //void OnApplicationQuit() { Debug.Log("OnApplicationQuit"); }

    void OnGUI()
    {
        if (Score > 0)
        {
            GUILayout.BeginArea(scoreDisplayArea);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(string.Format(scoreTextFormat, Score));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }
}