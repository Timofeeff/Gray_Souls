using UnityEngine;

public class BossMusic : MonoBehaviour
{
    [SerializeField] private MeleeEnemyBoss boss;
    [SerializeField] private Player player;
    [SerializeField] private GameObject backgroundMusic;
    [SerializeField] private AudioSource bossMusic;
    private BoxCollider2D col;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (boss.IsDie == true || player.IsDie == true)
            bossMusic.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            backgroundMusic.GetComponent<AudioSource>().Stop();
            bossMusic.Play();
            col.enabled = false;
        }
    }
}
