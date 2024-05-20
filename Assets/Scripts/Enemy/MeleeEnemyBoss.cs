using System.Collections;
using UnityEngine;

public class MeleeEnemyBoss : Entity
{
    [Header("Enemy Parametrs")]
    [SerializeField] private int lives;
    [SerializeField] private float newEnemySpeed;

    [Header("Attack Parametrs")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float newRange;

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

    private Player playerHealth;
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
                if (Lives >= 3)
                {
                    cooldownTimer = 0;
                    animator.SetTrigger("meleeAttack");
                }
                else
                {
                    cooldownTimer = 0;
                    animator.SetTrigger("meleeAttackNewPhase");
                    enemyPatrol.Speed = newEnemySpeed;
                    range = newRange;
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

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Player>();

        return hit.collider != null;
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.GetDamage();
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
        if (lives > 0 && collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
