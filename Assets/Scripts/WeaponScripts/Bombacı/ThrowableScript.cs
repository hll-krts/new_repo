using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableScript : MonoBehaviour
{
    public const string IS_ATTACKING = "IsAttacking";

    public GameObject _parentOBJ;
    public Transform currentTarget, _startingPos; // Alg�lanan hedef
    public ThrowableVariables wVars;
    public Animator animator;

    Vector3 directoion;

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

    public void Throwable(Vector3 targetPosition)
    {
        wVars.isThrown = true;
        wVars.explosionTime = Time.time + wVars.detonationTime;
        wVars.nextThrow = Time.time + wVars.throwCooldown;

        transform.parent = null;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, 1f);
    }
    public void Explosion()
    {
        Debug.Log("bom");
        wVars.isThrown = false;
        transform.parent = _parentOBJ.transform;
        transform.localPosition = new Vector3(1, 1, 0);
    }
    void OnDrawGizmosSelected()
    {
        // Alg�lama alan�n� g�rselle�tir
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, wVars.attackRadius);
    }
}
