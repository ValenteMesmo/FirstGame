using UnityEngine;
using System.Collections;

public class ScoreDisplayBehaviour : MonoBehaviour
{
    public int Score = 0;

    private Rect scoreDisplayArea;
    private string scoreTextFormat;

    protected override void OnAwake()
    {
        base.OnAwake();
        scoreDisplayArea = new Rect(0, Screen.height - Screen.height * 0.1f, Screen.width, Screen.height);
        scoreTextFormat = "<size=" + Screen.height * 0.05f + ">{0}</size>";
    }

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