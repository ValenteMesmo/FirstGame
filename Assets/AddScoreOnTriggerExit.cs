using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Trigger2DHandler))]
public class AddScoreOnTriggerExit : MonoBehaviour
{
    private Color OriginalColor;
    public Color NewColor;
    ScoreDisplayBehaviour Score;

    protected override void OnAwake()
    {
        Score = GlobalComponents.Get<ScoreDisplayBehaviour>();
        var trigger = GetComponent<Trigger2DHandler>();
        trigger.OnTriggerExit += trigger_OnTriggerExit;
        base.OnAwake();
    }

    void trigger_OnTriggerExit(object sender, Trigger2DEventArgs e)
    {
        Score.Score += 10;
    }
}
