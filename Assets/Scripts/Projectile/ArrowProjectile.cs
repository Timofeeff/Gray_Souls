using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;

    private bool hit;
    private float lifeTime;

    private Animator animator;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;

        if (animator != null)
        {
            animator.SetTrigger("explode");
        }
        else
            gameObject.SetActive(false);

        if (collision.tag == "Player")
            collision.GetComponent<Player>().GetDamage();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifeTime = 0;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
    }
}
