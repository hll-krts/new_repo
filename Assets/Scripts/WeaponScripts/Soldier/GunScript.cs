using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("Shotgun Settings")]
    public Transform firePoint; // Merminin ��k�� noktas�
    public GameObject bulletPrefab; // Mermi prefab�

    public Transform currentTarget; // Alg�lanan hedef

    public WeaponVariables wVars;

    private void Start()
    {
        wVars.nextFire = 0;
    }

    public void DetectTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, wVars.detectionRadius, wVars.targetLayer);
        if (hits.Length > 0)
        {
            currentTarget = hits[0].transform; // �lk alg�lanan hedefi se�
        }
        else
        {
            currentTarget = null; // Hedef yoksa s�f�rla
        }
    }

    public void RotateTowardsTarget(Transform target)
    {
        Vector3 direction = (new Vector3(target.position.x, target.position.y + 1, target.position.z) - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * wVars.rotationSpeed);
    }

    public void BurstFire(Vector3 targetPosition)
    {
        FireGun(targetPosition);
        StartCoroutine(BurstingFire(targetPosition));
    }
    IEnumerator BurstingFire(Vector3 targetPosition)
    {
        yield return new WaitForSeconds(wVars.fireRate / 15);
        FireGun(targetPosition);
        yield return new WaitForSeconds(wVars.fireRate / 15);
        FireGun(targetPosition);
    }
    public void FireGun(Vector3 targetPosition)
    {
        // Mermiyi olu�tur ve hedefe do�ru y�nlendir
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (targetPosition - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 10f; // H�z�n� ayarla

        DestroyBullet(bullet, 1.25f);

        wVars.nextFire = Time.time + wVars.fireRate;
    }
    public void FireShotGun()
    {
        for (int i = 0; i < wVars.bulletCount; i++)
        {
            // Mermi i�in koni a��s�n� hesapla
            float angle = (-wVars.spreadAngle / 2) + (wVars.spreadAngle / (wVars.bulletCount - 1)) * i;
            Quaternion rotation = Quaternion.Euler(0, angle, 0) * transform.rotation;

            // Mermiyi olu�tur ve y�n ver
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * wVars.bulletSpeed;

            DestroyBullet(bullet, 0.75f);

            wVars.nextFire = Time.time + wVars.fireRate;
        }
    }

    void DestroyBullet(GameObject bullet, float seconds)
    {
        Destroy(bullet, seconds);
    }

    void OnDrawGizmosSelected()
    {
        // Alg�lama alan�n� g�rselle�tir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, wVars.detectionRadius);
    }
}
