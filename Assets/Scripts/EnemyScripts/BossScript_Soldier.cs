using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript_Soldier : BossScript
{
    float nextTime = 0;
    public float duration;
    public void Special()
    {
        nextTime = Time.time + duration;
    }
    public void Update()
    {
        if (Time.time > nextTime && nextTime != 0)
        {
            nextTime = 0;
        }
    }
}
