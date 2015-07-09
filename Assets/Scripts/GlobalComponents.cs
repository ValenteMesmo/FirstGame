using System.Collections.Generic;
using UnityEngine;

public class GlobalComponents : MonoBehaviour
{
    public static bool FlippersEnabled;
    public static List<Rigidbody2D> Balls = new List<Rigidbody2D>();
    public static bool HideFireflyWave;

    private static GlobalComponents _global;
    protected static GlobalComponents Global
    {
        get
        {
            if (_global == null)
            {
                var go = GameObject.Find("GlobalComponents");
                if (go == null)
                    go = new GameObject("GlobalComponents");
                _global = go.GetComponent<GlobalComponents>();
                if (_global == null)
                    _global = go.AddComponent<GlobalComponents>();
                Initialaze();
            }
            return _global;
        }
    }

    private static void Initialaze()
    {
        FlippersEnabled = true;
        _global.GetComponent<ScoreDisplayBehaviour>().Score = 0;
        WrappedInput2.Reset();
        HideFireflyWave = true;
        Balls.Clear();
    }

    public static T Get<T>()
    {
        return Global.GetComponent<T>();
    }
}