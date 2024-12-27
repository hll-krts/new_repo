using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamitScript : ThrowableScript
{
    private void Start()
    {
        wVars.nextThrow = 0;
        wVars.explosionTime = 0;
    }

    private void Update()
    {
        if (wVars.isThrown && wVars.explosionTime < Time.time && wVars.explosionTime != 0f)
        {
            Explosion();
        }
        DetectTarget();
        if (currentTarget != null)
        {
            if (wVars.nextThrow < Time.time)
            {
                Throwable(currentTarget.transform.position);
            }
        }
    }
}
