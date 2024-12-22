using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public const string IS_ATTACKING = "IsAttacking";

    public GameObject _meleeRange;
    public Transform currentTarget; // Alg�lanan hedef
    public MeleeVariables wVars;
    private bool isAvailableToAttack;
    public Animator animator;

    private void Start()
    {
        wVars.cooldownTimer = 0f;
    }

    public void DetectTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, wVars.attackRadius, wVars.targetLayer);
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
    public void MeleeTimer()
    {
        if (wVars.isAttacking)
        {
            wVars.attackTime += Time.deltaTime;
            isAvailableToAttack = true;
            if (wVars.attackTime >= wVars.attackDuration)
            {
                isAvailableToAttack = false;
                wVars.cooldownTimer = Time.time + wVars.attackCooldown;
                wVars.isAttacking = false;
                _meleeRange.SetActive(false);
                wVars.attackTime = 0f;
            }
        }
    }
    public void Attack()
    {
        if (!wVars.isAttacking && !isAvailableToAttack)
        {
            _meleeRange.SetActive(true);
            wVars.isAttacking = true;
            animator.SetTrigger(IS_ATTACKING);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Alg�lama alan�n� g�rselle�tir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, wVars.attackRadius);
    }
}