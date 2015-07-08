using System.Collections.Generic;
using UnityEngine;

public class GlobalComponents : MonoBehaviour
{
    public static bool FlippersEnabled;
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
        //BallCount = 1;
        Balls.Clear();
    }

    public static List<Rigidbody2D> Balls = new List<Rigidbody2D>();

    //public static int BallCount;

    public static T Get<T>()
    {
        return Global.GetComponent<T>();
    }
}