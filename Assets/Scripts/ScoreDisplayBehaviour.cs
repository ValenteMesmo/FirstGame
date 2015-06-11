using UnityEngine;
using System.Collections;

public class ScoreDisplayBehaviour : MonoBehaviour
{
    public int Score = 0;

    void OnGUI()
    {
        GUILayout.Label(string.Format("<size=40>Score: {0}</size>", Score));
    }
}