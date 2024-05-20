using UnityEngine;

public class MeleeEnemy : Entity
{
    [Header("Enemy Parametrs")]
    [SerializeField] private int lives;

    [Header("Attack Parametrs")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;

    [Header("Collider Parametrs")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Coin Drop Probability")]
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private float probability;
    
    [Header("Player Parametrs")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Player playerHealth;
    private Animator animator;
    private EnemyPatrol enemyPatrol;
    private Collider2D col;

    float rnd;

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
                animator.SetTrigger("meleeAttack");
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

    public override void Die()
    {
        enemyPatrol.Speed = 0;
        col.enabled = false;
        animator.SetTrigger("die");

        rnd = Random.Range(0, 100);
        if (rnd <= probability)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
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
