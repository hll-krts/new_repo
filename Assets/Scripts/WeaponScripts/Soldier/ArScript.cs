using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArScript : GunScript
{
    void Update()
    {
        DetectTarget();
        if (currentTarget != null)
        {
            RotateTowardsTarget(currentTarget);
            if (wVars.nextFire < Time.time)
            {
                BurstFire(currentTarget.transform.position);
            }
        }
    }
}
