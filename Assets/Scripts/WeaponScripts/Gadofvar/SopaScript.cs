using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SopaScript : MeleeScript
{
    private void Update()
    {
        DetectTarget();
        if(currentTarget != null)
        {
            RotateTowardsTarget(currentTarget);
            if(wVars.cooldownTimer < Time.time)
            {
                Attack();
            }
        }
    }
}
