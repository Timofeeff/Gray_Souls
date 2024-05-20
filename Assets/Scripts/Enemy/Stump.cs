using UnityEngine;

public class Stump : Entity
{
    [SerializeField] private int lives;

    [Header("Coin Drop Probability")]
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private float probability;
    
    private Animator animator;
    private Collider2D col;

    float rnd;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        isDie = false;

        Lives = lives;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }

    public override void Die()
    {
        col.enabled = false;
        animator.SetTrigger("die");

        rnd = Random.Range(0, 100);
        if (rnd <= probability)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
}
