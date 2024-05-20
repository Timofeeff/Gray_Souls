using UnityEngine;

public class PatrolingEnemy : Entity
{
    [SerializeField] private int lives;
    
    [Header("Coin Drop Probability")]
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private float probability;
    
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
}
