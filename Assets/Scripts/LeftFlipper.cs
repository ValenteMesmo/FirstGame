using UnityEngine;

[RequireComponent(typeof(AudioClipPlus))]
public class LeftFlipper : MonoBehaviour
{
    public float speed = 600f;
    protected float LowerAngleLimit;
    public float UpperAngleLimit = 45f;
    protected Rigidbody2D rb2D;
    bool leftButtomPressed;

    private AudioClipPlus Audio;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioClipPlus>();
        LowerAngleLimit = (float)System.Math.Round(rb2D.rotation, 2);
        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.LeftButtonUp += inputs_LeftButtonUp;
        inputs.LeftButtonDown += inputs_LeftButtonDown;
    }

    void inputs_LeftButtonDown(object sender, System.EventArgs e)
    {
        if (GlobalComponents.FlippersEnabled)
        {
            leftButtomPressed = true;
            Audio.Play();
        }
    }

    void inputs_LeftButtonUp(object sender, System.EventArgs e)
    {
        leftButtomPressed = false;
    }

    void FixedUpdate()
    {
        if (leftButtomPressed)
            MoveUp();
        else
            MoveDown();
    }

    private void MoveDown()
    {
        if (rb2D.rotation > LowerAngleLimit)
            rb2D.MoveRotation(rb2D.rotation - speed * Time.fixedDeltaTime);
        else
            rb2D.MoveRotation(LowerAngleLimit);
    }

    private void MoveUp()
    {
        if (rb2D.rotation < UpperAngleLimit)
            rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime);
        else
            rb2D.MoveRotation(UpperAngleLimit);
    }


}