using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript_Kratos : BossScript
{
    [SerializeField] private GameObject _sopa, _levye, _balyoz, _balta;
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
        if (gameManager.minutes % 1 == 0)
        {
            switch (gameManager.seconds)
            {
                case 0: _sopa.SetActive(true); break;
                case 10: _levye.SetActive(true); break;
                case 20: _balyoz.SetActive(true); break;
                case 30: _balta.SetActive(true); break;
            }
        }
    }
}
