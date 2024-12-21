using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    [Header("Silah Ayarlar�")]
    public float fireRate = 1.0f; // Saniyede ka� kez ate� edecek
    public float detectionRadius = 5.0f; // Silah�n alg�lama yar��ap�
    public float fireAngle = 30.0f; // Ate�leme konisinin a��s� (derece)
    public GameObject bulletPrefab; // Mermi prefab�
    public Transform firePoint; // Merminin ��k�� noktas�
    public LayerMask targetLayer; // Hedef olarak alg�lanacak layer

    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            // Alg�lama yar��ap� i�inde hedef bul
            Collider[] targets = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
            if (targets.Length > 0)
            {
                Vector3 targetPosition = targets[0].transform.position; // �lk hedefe odaklan
                Fire(targetPosition); // 3 mermi ate�le
                fireCooldown = 1f / fireRate;
            }
        }
    }

    void Fire(Vector3 targetPosition)
    {
        // Orta noktaya do�ru mermi g�nder
        FireBullet(targetPosition);

        // Sol kenara do�ru mermi g�nder
        FireBulletWithAngle(-fireAngle / 2);

        // Sa� kenara do�ru mermi g�nder
        FireBulletWithAngle(fireAngle / 2);
    }

    void FireBullet(Vector3 targetPosition)
    {
        // Mermiyi olu�tur ve hedefe do�ru y�nlendir
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (targetPosition - firePoint.position).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * 10f; // Mermi h�z�
        }
    }

    void FireBulletWithAngle(float angle)
    {
        // Mermiyi belirtilen a��ya do�ru g�nder
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * 10f; // Mermi h�z�
        }
    }

    void OnDrawGizmosSelected()
    {
        // Alg�lama alan�n� ve ate� a��s�n� g�rselle�tir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.blue;
        Vector3 leftLimit = Quaternion.Euler(0, -fireAngle / 2, 0) * transform.forward;
        Vector3 rightLimit = Quaternion.Euler(0, fireAngle / 2, 0) * transform.forward;

        Gizmos.DrawRay(transform.position, leftLimit * detectionRadius);
        Gizmos.DrawRay(transform.position, rightLimit * detectionRadius);
    }
}
