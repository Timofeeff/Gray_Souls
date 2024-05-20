using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Instantiate(impactEffect);
            Player.Instance.CoinAmount++;
            Destroy(gameObject);
        }
    }
}
