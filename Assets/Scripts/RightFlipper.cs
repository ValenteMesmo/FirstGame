using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioClipPlus))]
public class RightFlipper : MonoBehaviour
{
    public float speed = 600f;
    protected float LowerAngleLimit;
    public float UpperAngleLimit = 45f;
    protected Rigidbody2D rb2D;
    bool rightButtomPressed;

    private AudioClipPlus Audio;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioClipPlus>();
        LowerAngleLimit = (float)System.Math.Round(rb2D.rotation, 2);
        speed = -speed;
        UpperAngleLimit = -UpperAngleLimit;
        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.RightButtonUp += inputs_RightButtonUp;
        inputs.RightButtonDown += inputs_RightButtonDown;
    }

    void inputs_RightButtonUp(object sender, System.EventArgs e)
    {
        rightButtomPressed = false;
    }

    void inputs_RightButtonDown(object sender, System.EventArgs e)
    {
        if (GlobalComponents.FlippersEnabled)
        {
            rightButtomPressed = true;
            Audio.Play();
        }
    }

    void FixedUpdate()
    {
        if (rightButtomPressed)
            MoveUp();
        else
            MoveDown();
    }

    private void MoveDown()
    {
        if (rb2D.rotation < LowerAngleLimit)
            rb2D.MoveRotation(rb2D.rotation - speed * Time.fixedDeltaTime);
        else
            rb2D.MoveRotation(LowerAngleLimit);
    }

    private void MoveUp()
    {
        if (rb2D.rotation > UpperAngleLimit)
            rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime);
        else
            rb2D.MoveRotation(UpperAngleLimit);
    }
}

