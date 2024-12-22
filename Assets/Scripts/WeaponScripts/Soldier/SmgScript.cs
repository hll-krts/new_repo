using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgScript : GunScript
{    void Update()
    {
        DetectTarget();
        if (currentTarget != null)
        {
            RotateTowardsTarget(currentTarget);
            if (wVars.nextFire < Time.time)
            {
                FireGun(currentTarget.transform.position);
            }
        }
    }
}
