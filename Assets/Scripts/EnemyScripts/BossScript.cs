using UnityEngine;

public class BossScript : MonoBehaviour
{
    GameManager gameManager;
    public GameObject bossOrigin;
    public CommonVariables commonVariables;
    public WeaponVariables weaponVariables;

    private void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        GetComponent<Unit>().speed = commonVariables.bossMovSpd;
    }

    public void ReturnToOrigin()
    {
        transform.position = bossOrigin.transform.position;
        transform.parent = bossOrigin.transform;
        commonVariables.RestoreHP();
        GetComponent<Unit>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public void GetHit(float hitDamage)
    {
        if (commonVariables.GetDamage(hitDamage) == 0)
        {
            ReturnToOrigin();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            go.GetComponent<PlayerMovement>().BossHit();
        }
    }
}
