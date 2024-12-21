using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArScript : MonoBehaviour
{
    [Header("Silah Ayarlarý")]
    public float fireRate = 1.0f; // Saniyede kaç kez ateþ edecek
    public float detectionRadius = 5.0f; // Silahýn algýlama yarýçapý
    public GameObject bulletPrefab; // Mermi prefabý
    public Transform firePoint; // Merminin çýkýþ noktasý
    public LayerMask targetLayer; // Hedef olarak algýlanacak layer

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
        // Mermiyi oluþtur ve hedefe doðru yönlendir
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (targetPosition - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 10f; // Hýzýný ayarla
        Debug.Log("Ateþ edildi!");
    }

    void OnDrawGizmosSelected()
    {
        // Algýlama alanýný görselleþtir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
