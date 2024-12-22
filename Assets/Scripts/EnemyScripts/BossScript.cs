using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] SpriteRenderer sprite;
    public GameObject bossOrigin, player;
    public CommonVariables commonVariables;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if (player.transform.position.x < transform.position.x)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }

    public void ReturnToOrigin()
    {
        transform.position = bossOrigin.transform.position;
        transform.parent = bossOrigin.transform;
        commonVariables.RestoreHP();
    }

    public void GetHit(float hitDamage)
    {
        if (commonVariables.GetDamage(hitDamage) == 0)
        {
            ReturnToOrigin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHandGunAmmo"))
        {
            GetHit(10);
        }
    }
}
