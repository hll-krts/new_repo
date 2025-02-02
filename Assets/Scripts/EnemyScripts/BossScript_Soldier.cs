using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript_Soldier : BossScript
{
    [SerializeField] private GameObject _handgun, _shotgun, _ar, _smg;
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
            //special i�in
            nextTime = 0;
        }
        if(gameManager.minutes % 1 == 0)
        {
            switch (gameManager.seconds)
            {
                case 0: _handgun.SetActive(true); break;
                case 10: _shotgun.SetActive(true); break;
                case 20: _smg.SetActive(true); break;
                case 30: _ar.SetActive(true); break;
            }
        }
    }
}
