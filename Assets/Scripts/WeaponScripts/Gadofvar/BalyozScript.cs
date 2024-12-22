using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalyozScript : MeleeScript
{
    private void Update()
    {
        MeleeTimer();

        DetectTarget();
        if (currentTarget != null)
        {
            RotateTowardsTarget(currentTarget);
            if (wVars.cooldownTimer < Time.time)
            {
                Attack();
            }
        }
    }
}
