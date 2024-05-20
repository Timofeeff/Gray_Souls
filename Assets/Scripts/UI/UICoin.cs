using UnityEngine;
using UnityEngine.UI;

public class UICoin : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text text;

    private void Awake()
    {
        player.addCoins.AddListener(CoinUpdate);
    }

    private void OnDestroy()
    {
        player.addCoins.RemoveListener(CoinUpdate);
    }

    private void CoinUpdate()
    {
        text.text = player.CoinAmount.ToString();
    }
}
