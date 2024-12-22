using UnityEngine;

public class ShootgunScript : GunScript
{    void Update()
    {
        DetectTarget();
        if (currentTarget != null)
        {
            RotateTowardsTarget(currentTarget);
            if (wVars.nextFire < Time.time)
            {
                FireShotGun();
            }
        }
    }
}
