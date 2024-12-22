using UnityEngine;

[CreateAssetMenu]
public class WeaponVariables : ScriptableObject
{
    [Header("HandGun Settings")]
    public float bulletSpeed; // Mermi h�z�
    public float spreadAngle; // Koni geni�li�i
    public int bulletCount; // Koni i�inde ka� mermi
    public int burstCount; //Burst olarak ka� mermi
    public float rotationSpeed; // Silah�n d�nme h�z�
    public float fireRate, nextFire = 0;

    [Header("Detection Settings")]
    public float detectionRadius; // Alg�lama yar��ap�
    public LayerMask targetLayer; // Hangi katmandaki hedefler alg�lanacak
}
