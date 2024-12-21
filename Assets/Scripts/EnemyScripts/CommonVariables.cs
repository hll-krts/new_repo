using UnityEngine;

[CreateAssetMenu]
public class CommonVariables : ScriptableObject
{
    public float bossMaxHP;
    public float bossMovSpd;
    float bossHP;

    public void RestoreHP()
    {
        bossHP = bossMaxHP;
    }
    public float GetDamage(float damage)
    {
        if (bossHP - damage <= 0)
        {
            return 0;
        }
        else
        {
            bossHP -= damage;
            return bossHP;
        }
    }
}
