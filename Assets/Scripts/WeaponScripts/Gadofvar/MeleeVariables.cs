using UnityEngine;

[CreateAssetMenu]
public class MeleeVariables : ScriptableObject
{
    [Header("Levye Ayarlar�")]
    public bool isAttacking;
    public float attackDuration;
    public float attackRadius;

    public float attackDamage;

    public float attackCooldown;
    public float attackTime = 0f;
    public float cooldownTimer = 0f;

    public float rotationSpeed; // Silah�n d�nme h�z�

    public LayerMask targetLayer;
}
