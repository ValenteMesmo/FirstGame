using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Trigger2DHandler))]
public class DisableFlipperOnTrigger : MonoBehaviour {
    //not used
    protected override void OnAwake()
    {
        base.OnAwake();
        var trigger = GetComponent<Trigger2DHandler>();
        trigger.OnTriggerStay += trigger_OnTriggerStay;
        trigger.OnTriggerExit += trigger_OnTriggerExit;
    }

    void trigger_OnTriggerExit(object sender, Trigger2DEventArgs e)
    {
        GlobalComponents.FlippersEnabled = true;
    }

    void trigger_OnTriggerStay(object sender, Trigger2DEventArgs e)
    {
        GlobalComponents.FlippersEnabled = false;
    }
}
