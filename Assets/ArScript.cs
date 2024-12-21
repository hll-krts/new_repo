using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArScript : MonoBehaviour
{
    [Header("Silah Ayarlar�")]
    public float fireRate = 1.0f; // Saniyede ka� kez ate� edecek
    public float detectionRadius = 5.0f; // Silah�n alg�lama yar��ap�
    public GameObject bulletPrefab; // Mermi prefab�
    public Transform firePoint; // Merminin ��k�� noktas�
    public LayerMask targetLayer; // Hedef olarak alg�lanacak layer

    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        Collider[] targets = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
        if (targets.Length > 0 && fireCooldown <= 0f)
        {
            Fire(targets[0].transform.position);
            fireCooldown = 1f / fireRate;
        }
    }

    void Fire(Vector3 targetPosition)
    {
        // Mermiyi olu�tur ve hedefe do�ru y�nlendir
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (targetPosition - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 10f; // H�z�n� ayarla
        Debug.Log("Ate� edildi!");
    }

    void OnDrawGizmosSelected()
    {
        // Alg�lama alan�n� g�rselle�tir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
