using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            if (Player.Instance.Health == 5)
            {
                return;
            }
            else
            {
                Instantiate(impactEffect);
                Player.Instance.Health += 1;
                Destroy(gameObject);
            }
        }
    }
}
