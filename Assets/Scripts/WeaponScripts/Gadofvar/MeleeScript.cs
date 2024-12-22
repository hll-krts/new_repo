using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public GameObject _meleeRange;
    public Transform currentTarget; // Algýlanan hedef
    public MeleeVariables wVars;

    private void Start()
    {
        wVars.cooldownTimer = 0f;
    }
    public void DetectTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, wVars.attackRadius, wVars.targetLayer);
        if (hits.Length > 0)
        {
            currentTarget = hits[0].transform; // Ýlk algýlanan hedefi seç
        }
        else
        {
            currentTarget = null; // Hedef yoksa sýfýrla
        }
    }
    public void RotateTowardsTarget(Transform target)
    {
        Vector3 direction = (new Vector3(target.position.x, target.position.y + 1, target.position.z) - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * wVars.rotationSpeed);
    }
    public void MeleeTimer()
    {
        if (wVars.isAttacking)
        {
            wVars.attackTime += Time.deltaTime;
            if (wVars.attackTime >= wVars.attackDuration)
            {
                wVars.attackTime = 0f;
                wVars.cooldownTimer = Time.time + wVars.attackCooldown;
                wVars.isAttacking = false;
                _meleeRange.SetActive(false); 
            }
        }
    }
    public void Attack()
    {
        if (!wVars.isAttacking)
        {
            _meleeRange.SetActive(true);
            wVars.isAttacking = true;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Algýlama alanýný görselleþtir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, wVars.attackRadius);
    }
}