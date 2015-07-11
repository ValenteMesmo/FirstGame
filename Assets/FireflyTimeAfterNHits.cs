using UnityEngine;
using System.Collections;
using System;

public class FireflyTimeAfterNHits : MonoBehaviour
{
    Animator Animator;

    private int N = 4;
    private int currentValue = 0;

    public MarmotasBehaviour MarmotasBehaviour;

    void Start()
    {
        if (MarmotasBehaviour == null)
            throw new Exception("MarmotasBehaviour property is required");
        MarmotasBehaviour.OnObjectiveAchieved += MarmotasBehaviour_OnObjectiveAchieved;
        Animator = GetComponent<Animator>();
    }

    void MarmotasBehaviour_OnObjectiveAchieved(object sender, EventArgs e)
    {
        GlobalComponents.HideFireflyWave = true;
        currentValue = 0;
        Animator.SetInteger("damage", currentValue);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Animator.SetInteger("damage", ++currentValue);

            if (currentValue >= N)
            {
                GlobalComponents.HideFireflyWave = false;                
            }
        }
    }
}
