using UnityEngine;
[CreateAssetMenu]
public class ThrowableVariables : ScriptableObject
{
    [Header("Levye Ayarlarý")]
    public float throwingForce;
    public float detonationTime;
    public float explosionTime;

    public bool isThrown;
    public float nextThrow;
    public float throwCooldown;

    public float attackRadius;

    public LayerMask targetLayer;
}
