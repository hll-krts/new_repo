using UnityEngine;

public class HandGunScript : GunScript
{
    void Update()
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
