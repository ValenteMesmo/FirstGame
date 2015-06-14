using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BaseCollider2DHandler))]
[RequireComponent(typeof(SpriteRendererHandler))]
public class Launcher : MonoBehaviour
{
    float currentPontential = 0f;
    public float potentialIncrement = 10f;
    public float maximumPotential = 4000f;
    IVibration Vibration;
    bool vibrating;

    ISpriteRendererHandler SpriteRendererHandler;

    protected override void OnAwake()
    {
        base.OnAwake();
        var collider = GetComponent<BaseCollider2DHandler>();
        SpriteRendererHandler = GetComponent<SpriteRendererHandler>();
        collider.OnCollisionStay += collider_OnCollisionStay;
        Vibration = new VibrationHandler();
    }



    void Update()
    {
        if (!vibrating && (WrappedInput2.LeftInputPressed() || WrappedInput2.RightInputPressed()) && !GameFlags.FlippersEnabled)
        {
            vibrating = true;

            if (currentPontential <= maximumPotential)
                Vibration.Vibrate(10);

            DelayExecution(() =>
            {
                vibrating = false;
            }, 0.2f);
        }

        SpriteRendererHandler.SetColor((currentPontential / maximumPotential), 0.5f, 0.5f);
    }

    void collider_OnCollisionStay(object sender, Collision2DEventArgs e)
    {
        if (e.Rigidbody != null)
        {
            if (WrappedInput2.LeftInputPressed() || WrappedInput2.RightInputPressed())
            {
                currentPontential += potentialIncrement;
            }
            else
            {
                if (currentPontential > 0f)
                {
                    e.Rigidbody.AddForce(0f, currentPontential);
                    currentPontential = 0f;
                }
            }
        }
    }
}
