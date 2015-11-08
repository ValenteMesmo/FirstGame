using UnityEngine;
using System.Collections;

public class SetWizardIsDeadGlobalValue : MonoBehaviour
{
    public void SetWizardAsDead()
    {
        GlobalComponents.WizardIsDead = true;
    }

    public void SetWizardAsNotDead()
    {
        GlobalComponents.WizardIsDead = false;
    }
}
