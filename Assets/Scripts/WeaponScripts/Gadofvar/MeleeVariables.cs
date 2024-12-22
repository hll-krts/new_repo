using UnityEngine;

[CreateAssetMenu]
public class MeleeVariables : ScriptableObject
{
    [Header("Levye Ayarlarý")]
    public bool isAttacking;
    public float attackDuration;
    public float attackRadius;

    public float attackDamage;

    public float attackCooldown;
    public float attackTime = 0f;
    public float cooldownTimer = 0f;

    public float rotationSpeed; // Silahýn dönme hýzý

    public LayerMask targetLayer;
}
