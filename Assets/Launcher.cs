using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
    float currentPontential = 0f;
    public float potentialIncrement = 10f;
    public float maximumPotential = 4000f;
    IVibration Vibration;

    SpriteRenderer SpriteRendererHandler;

    protected void Awake()
    {       
        SpriteRendererHandler = GetComponent<SpriteRenderer>();
        Vibration = new VibrationHandler(this);
    }

    void Update()
    {
        if ((WrappedInput2.GetLeftInputPressed() || WrappedInput2.GetRightInputPressed()) && !GlobalComponents.FlippersEnabled)
        {
            if (currentPontential <= maximumPotential)
                Vibration.Vibrate(10);
        }

        SpriteRendererHandler.color = new Color((currentPontential / maximumPotential), 0.5f, 0.5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        {
            if (WrappedInput2.GetLeftInputPressed() || WrappedInput2.GetRightInputPressed())
            {
                currentPontential += potentialIncrement;
            }
            else
            {
                if (currentPontential > 0f)
                {
                    collision.rigidbody.AddForce(new Vector2( 0f, currentPontential));
                    currentPontential = 0f;
                }
            }
        }
    }
}
