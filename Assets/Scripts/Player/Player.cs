using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum States
{
    idle,
    run,
    jump,
    attack,
    die
}

public class Player : Entity
{
    [Header("Player Parametrs")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int health;
    [SerializeField] private float attackRange;

    [Header("Hearts Parametrs")]
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [Header("Death Player Parametrs")]
    [SerializeField] private GameObject deathPanel;

    [Header("Sounds Parametrs")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hitEnemySound;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dieSound;

    [HideInInspector] public UnityEvent addCoins;

    public int Health { get => health; set => health = value; }
    public float Speed { get => speed; set => speed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }

    private bool isGrounded = false;

    [Header("Attack Parametrs")]
    public bool isAttacking = false;
    public bool isRecharged = true; 

    public Transform attackPos;

    public LayerMask enemy;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    private int coinAmount;

    public int CoinAmount
    { get { return coinAmount; } set { coinAmount = value; addCoins.Invoke(); } }

    public static Player Instance { get; set; }

    private States State 
    {
        get { return (States)animator.GetInteger("state"); } 
        set { animator.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        Lives = 5;
        health = Lives;
        Instance = this; 
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isRecharged = true;    
    }

    private void Start()
    {
        CoinAmount = PlayerPrefs.GetInt("CoinAmount", 0);
        attackRange = PlayerPrefs.GetFloat("Attack", attackRange);
        speed = PlayerPrefs.GetFloat("Speed", speed);
        jumpForce = PlayerPrefs.GetFloat("JumpForce", jumpForce);
        SaveLevel();
    }

    private void OnDestroy()
    {
        SavePlayerProperties();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void Update()
    {
        PlayerControl();

        PlayerHealth();
    }

    private void PlayerControl()
    {
        if (isGrounded && !isAttacking && health > 0) State = States.idle;

        if (Input.GetButton("Horizontal") && !isAttacking && health > 0)
            Run();

        if (isGrounded && Input.GetButtonDown("Jump") && !isAttacking)
            Jump();

        if (!isAttacking && isGrounded && Input.GetButtonDown("Fire1") && health > 0)
            Attack();
    }

    private void PlayerHealth()
    {
        if (health > Lives) 
            health = Lives;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < Lives)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        SoundManager.Instance.PlaySound(jumpSound);

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Attack()
    {
        SoundManager.Instance.PlaySound(attackSound);

        State = States.attack;
        isAttacking = true;
        isRecharged = false;

        StartCoroutine(AttackAnimation());
        StartCoroutine(AttackCoolDown());
    }

    private void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Entity>().GetDamage();
            SoundManager.Instance.PlaySound(hitEnemySound);

            if (!colliders[i].GetComponent<Entity>().GetIsDie())
            {           
                StartCoroutine(EnemyOnAttack(colliders[i]));
            }
                
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.6f);
        isRecharged = true;
    }

    private IEnumerator EnemyOnAttack(Collider2D enemy)
    {
        SpriteRenderer enemyColor = enemy.GetComponentInChildren<SpriteRenderer>();
        enemyColor.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        enemyColor.color = new Color(1, 1, 1);
    }

    private IEnumerator PlayerDamage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1);
    }

    private void CheckGrounded()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1; 

        if (!isGrounded && health > 0) State = States.jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            this.transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            this.transform.parent = null;
    }

    private void OnDeath()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public override void Die()
    {
        SoundManager.Instance.PlaySound(dieSound);
        State = States.die;
    }

    public override void GetDamage()
    {
        SoundManager.Instance.PlaySound(damageSound);

        health -= 1;

        StartCoroutine(PlayerDamage());

        if (health == 0)
        {
            foreach (var h in hearts)
                h.sprite = emptyHeart;

            coinAmount = 0;
            isDie = true;
            Die();
        }
    }

    private void SaveLevel()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    private void SavePlayerProperties()
    {
        PlayerPrefs.SetInt("CoinAmount", CoinAmount);
        PlayerPrefs.SetFloat("Attack", attackRange);
        PlayerPrefs.SetFloat("Speed", speed);
        PlayerPrefs.SetFloat("JumpForce", jumpForce);
    }
}
