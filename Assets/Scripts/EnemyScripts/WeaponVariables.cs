using UnityEngine;

[CreateAssetMenu]
public class WeaponVariables : ScriptableObject
{
    [Header("HandGun Settings")]
    public float bulletSpeed; // Mermi hýzý
    public float spreadAngle; // Koni geniþliði
    public int bulletCount; // Koni içinde kaç mermi
    public int burstCount; //Burst olarak kaç mermi
    public float rotationSpeed; // Silahýn dönme hýzý
    public float fireRate, nextFire = 0;

    [Header("Detection Settings")]
    public float detectionRadius; // Algýlama yarýçapý
    public LayerMask targetLayer; // Hangi katmandaki hedefler algýlanacak
}
