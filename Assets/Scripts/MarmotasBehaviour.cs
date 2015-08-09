using UnityEngine;
using System.Collections;
using System;

public class MarmotasBehaviour : MonoBehaviour
{
    MarmotaController MarmotaController;

    SpriteRenderer leftRenderer;
    SpriteRenderer centralRenderer;
    SpriteRenderer rightRenderer;
    Animator Animator;

    private ColorSequence ColorSequence;
    private ScoreDisplayBehaviour ScoreDisplayBehaviour;

    void Start()
    {
        var left = transform.Find("left");
        leftRenderer = left.GetComponent<SpriteRenderer>();
        var leftPassThruBehaviour = left.GetComponent<PassThruBehaviour>();
        leftPassThruBehaviour.OnPassThru += left_OnPassThru;

        var central = transform.Find("central");
        centralRenderer = central.GetComponent<SpriteRenderer>();
        var centralPassThruBehaviour = central.GetComponent<PassThruBehaviour>();
        centralPassThruBehaviour.OnPassThru += central_OnPassThru;

        var right = transform.Find("right");
        rightRenderer = right.GetComponent<SpriteRenderer>();
        var rightPassThruBehaviour = right.GetComponent<PassThruBehaviour>();
        rightPassThruBehaviour.OnPassThru += right_OnPassThru;

        MarmotaController = new MarmotaController();
        MarmotaController.OnAllActivated += MarmotaController_OnAllActivated;

        ColorSequence = GlobalComponents.Get<ColorSequence>();
        ScoreDisplayBehaviour = GlobalComponents.Get<ScoreDisplayBehaviour>();

        var inputs = GlobalComponents.Get<ControlsPlayerInputs>();
        inputs.LeftButtonDown += inputs_LeftButtonDown;
        inputs.RightButtonDown += inputs_RightButtonDown;

        Animator = GetComponent<Animator>();
    }

    void inputs_RightButtonDown(object sender, EventArgs e)
    {
        MarmotaController.ShuffleRight();
    }

    void inputs_LeftButtonDown(object sender, EventArgs e)
    {
        MarmotaController.ShuffleLeft();        
    }

    public event EventHandler OnObjectiveAchieved;

    void MarmotaController_OnAllActivated(object sender, EventArgs e)
    {
        MarmotaController.ToggleRight();
        MarmotaController.ToggleCentral();
        MarmotaController.ToggleLeft();
        ScoreDisplayBehaviour.AddScore(100);
        ColorSequence.ChangeColor();

        Animator.SetTrigger("boom");

        if (OnObjectiveAchieved != null)
            OnObjectiveAchieved(this, null);
    }

    void right_OnPassThru(object sender, EventArgs e)
    {
        MarmotaController.ToggleRight();
    }

    void central_OnPassThru(object sender, EventArgs e)
    {
        MarmotaController.ToggleCentral();
    }

    void left_OnPassThru(object sender, EventArgs e)
    {

        MarmotaController.ToggleLeft();
    }

    bool leftButtonDown;
    bool rightButtonDown;

    void Update()
    {
        ChangeColors();
    }

    private void ChangeColors()
    {
        if (MarmotaController.IsLeftMarmotaActive())
            leftRenderer.color = Color.yellow;
        else
            leftRenderer.color = Color.black;

        if (MarmotaController.IsCentralMarmotaActive())
            centralRenderer.color = Color.yellow;
        else
            centralRenderer.color = Color.black;

        if (MarmotaController.IsRightMarmotaActive())
            rightRenderer.color = Color.yellow;
        else
            rightRenderer.color = Color.black;
    }
}

public class MarmotaController
{
    private bool right = false;
    private bool left = false;
    private bool central = false;

    public event EventHandler OnAllActivated;

    public MarmotaController()
    {

    }

    public bool IsRightMarmotaActive()
    {
        return right;
    }

    public bool IsLeftMarmotaActive()
    {
        return left;
    }

    public bool IsCentralMarmotaActive()
    {
        return central;
    }

    public void ToggleRight()
    {
        right = !right;
        FireEventIfAllActivated();
    }

    public void ToggleLeft()
    {
        left = !left;
        FireEventIfAllActivated();
    }

    public void ToggleCentral()
    {
        central = !central;
        FireEventIfAllActivated();
    }

    public void ShuffleRight()
    {
        var tempRight = right;
        right = central;
        central = left;
        left = tempRight;
    }

    public void ShuffleLeft()
    {
        var tempLeft = left;
        left = central;
        central = right;
        right = tempLeft;
    }

    private void FireEventIfAllActivated()
    {
        if (OnAllActivated != null && left && central && right)
            OnAllActivated(this, default(EventArgs));
    }
}
