using UnityEngine;

[RequireComponent(typeof(AudioClipPlus))]
public abstract class BaseFlipper : MonoBehaviour
{
    public float speed = 600f;
    protected float LowerAngleLimit; //= -15f;
    public float UpperAngleLimit = 45f;
    protected Rigidbody2D rb2D;

    protected virtual void OnInit() { }
    protected abstract bool ConditionToMoveDown();
    protected abstract bool ConditionToMoveUp();
    protected abstract bool CheckButtomPressed();

    private AudioClipPlus Audio;

    private bool keyDown = false;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioClipPlus>();
        LowerAngleLimit = (float)System.Math.Round(rb2D.rotation, 2);
        OnInit();
    }

    void FixedUpdate()
    {
        if (GameFlags.FlippersEnabled)
        {
            if (CheckButtomPressed())
                MoveUp();
            else
                MoveDown();
        }
        else
            MoveDown();
    }

    private void MoveDown()
    {
        if (ConditionToMoveDown())
        {
            keyDown = false;
            rb2D.MoveRotation(rb2D.rotation - speed * Time.fixedDeltaTime);
        }
        else
            rb2D.MoveRotation(LowerAngleLimit);
    }

    private void MoveUp()
    {
        if (ConditionToMoveUp())
        {
            if (keyDown == false)
            {
                keyDown = true;
                Audio.Play();
            }
            rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime);
        }
        else
            rb2D.MoveRotation(UpperAngleLimit);
    }

}