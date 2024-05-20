using System.Collections;
using UnityEngine;

public class RangedEnemyBoss : Entity
{
    [Header("Enemy Parametrs")]
    [SerializeField] private int lives;
    [SerializeField] private float newEnemySpeed;

    [Header("Attack Parametrs")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("Collider Parametrs")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Parametrs")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Death Boss Parametrs")]
    [SerializeField] private GameObject finishPanel;

    [Header("Sounds Parametrs")]
    [SerializeField] private AudioClip playerWin;

    private Animator animator;
    private EnemyPatrol enemyPatrol;
    private Collider2D col;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        Lives = lives;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("rangedAttack");

                if (Lives >= 5)
                {
                    cooldownTimer = 0;
                    animator.SetTrigger("rangedAttack");
                }
                else
                {
                    cooldownTimer = 0;
                    animator.SetTrigger("rangedAttack");
                    enemyPatrol.Speed = newEnemySpeed;
                }
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void OnDeath()
    {
        StartCoroutine(OnDeathDelay());
        SoundManager.Instance.PlaySound(playerWin);
    }

    public override void Die()
    {
        enemyPatrol.Speed = 0;
        col.enabled = false;
        animator.SetTrigger("die");
    }

    private IEnumerator OnDeathDelay()
    {
        yield return new WaitForSeconds(3);
        finishPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }
}
