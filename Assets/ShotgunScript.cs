using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    [Header("Silah Ayarlarý")]
    public float fireRate = 1.0f; // Saniyede kaç kez ateþ edecek
    public float detectionRadius = 5.0f; // Silahýn algýlama yarýçapý
    public float fireAngle = 30.0f; // Ateþleme konisinin açýsý (derece)
    public GameObject bulletPrefab; // Mermi prefabý
    public Transform firePoint; // Merminin çýkýþ noktasý
    public LayerMask targetLayer; // Hedef olarak algýlanacak layer

    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            // Algýlama yarýçapý içinde hedef bul
            Collider[] targets = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
            if (targets.Length > 0)
            {
                Vector3 targetPosition = targets[0].transform.position; // Ýlk hedefe odaklan
                Fire(targetPosition); // 3 mermi ateþle
                fireCooldown = 1f / fireRate;
            }
        }
    }

    void Fire(Vector3 targetPosition)
    {
        // Orta noktaya doðru mermi gönder
        FireBullet(targetPosition);

        // Sol kenara doðru mermi gönder
        FireBulletWithAngle(-fireAngle / 2);

        // Sað kenara doðru mermi gönder
        FireBulletWithAngle(fireAngle / 2);
    }

    void FireBullet(Vector3 targetPosition)
    {
        // Mermiyi oluþtur ve hedefe doðru yönlendir
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (targetPosition - firePoint.position).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * 10f; // Mermi hýzý
        }
    }

    void FireBulletWithAngle(float angle)
    {
        // Mermiyi belirtilen açýya doðru gönder
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * 10f; // Mermi hýzý
        }
    }

    void OnDrawGizmosSelected()
    {
        // Algýlama alanýný ve ateþ açýsýný görselleþtir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.blue;
        Vector3 leftLimit = Quaternion.Euler(0, -fireAngle / 2, 0) * transform.forward;
        Vector3 rightLimit = Quaternion.Euler(0, fireAngle / 2, 0) * transform.forward;

        Gizmos.DrawRay(transform.position, leftLimit * detectionRadius);
        Gizmos.DrawRay(transform.position, rightLimit * detectionRadius);
    }
}
