using UnityEngine;
using System.Collections;

public class SetAnimatorVariableWhenFunguysAreDead : MonoBehaviour
{
    public FungusController FungusController;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
        FungusController.FungusDestroyed += Marmotas_OnAllActivated;
    }

    void Marmotas_OnAllActivated(object sender, System.EventArgs e)
    {
        Animator.SetBool("dead", false);
    }
}
