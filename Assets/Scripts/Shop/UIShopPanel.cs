using UnityEngine;
using UnityEngine.UI;

public class UIShopPanel : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private Player player;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private UIButton buttonAttack;
    [SerializeField] private UIButton buttonSpeed;
    [SerializeField] private UIButton buttonJump;

    [Header("Shop Buttons")]
    [SerializeField] private Button attackButtonBuy;
    [SerializeField] private Button speedButtonBuy;
    [SerializeField] private Button jumpButtonBuy;

    [Header("Shop Prace")]
    [SerializeField] private int praceUpgradeAttack;
    [SerializeField] private int praceUpgradeSpeed;
    [SerializeField] private int praceUpgradeJump;

    [Header("Text Parametrs")]
    [SerializeField] private Text upgradeAttackText;
    [SerializeField] private Text upgradeSpeedText;
    [SerializeField] private Text upgradeJumpText;

    [Header("Ability enhancement options")]
    [SerializeField] private float upgradeAttack;
    [SerializeField] private float upgradeSpeed;
    [SerializeField] private float upgradeJump;

    private int amountUpgradeAttack;
    private int amountUpgradeSpeed;
    private int amountUpgradeJump;


    private void Start()
    { 
        amountUpgradeAttack = PlayerPrefs.GetInt("amountAttack", amountUpgradeAttack);
        amountUpgradeSpeed = PlayerPrefs.GetInt("amountSpeed", amountUpgradeSpeed);
        amountUpgradeJump = PlayerPrefs.GetInt("amountJump", amountUpgradeJump);

        CheckAmountUpgrade();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("amountAttack", amountUpgradeAttack);
        PlayerPrefs.SetInt("amountSpeed", amountUpgradeSpeed);
        PlayerPrefs.SetInt("amountJump", amountUpgradeJump);
    }

    private void CheckAmountUpgrade()
    {
        if (amountUpgradeAttack > 0)
        {
            upgradeAttackText.text = " куплено".ToString();
            attackButtonBuy.interactable = false;
            buttonAttack.Interactable = false;
        }
        else
            upgradeAttackText.text = praceUpgradeAttack + " золотых".ToString();

        if (amountUpgradeSpeed > 0)
        {
            upgradeSpeedText.text = " куплено".ToString();
            speedButtonBuy.interactable = false;
            buttonSpeed.Interactable = false;
        }
        else
            upgradeSpeedText.text = praceUpgradeSpeed + " золотых".ToString();

        if (amountUpgradeJump > 0)
        {
            upgradeJumpText.text = " куплено".ToString();
            jumpButtonBuy.interactable = false;
            buttonJump.Interactable = false;
        }
        else
            upgradeJumpText.text = praceUpgradeJump + " золотых".ToString();
    }

    public void UpgradeAttack()
    {
        if (player.CoinAmount >= praceUpgradeAttack)
        {
            player.AttackRange += upgradeAttack;
            player.CoinAmount -= praceUpgradeAttack;
            amountUpgradeAttack += 1;
            upgradeAttackText.text = " куплено".ToString();
            attackButtonBuy.interactable = false;
            buttonAttack.Interactable = false;
        }
    }

    public void UpgradeSpeed()
    {
        if (player.CoinAmount >= praceUpgradeSpeed)
        {
            player.Speed += upgradeSpeed;
            player.CoinAmount -= praceUpgradeSpeed;
            amountUpgradeSpeed += 1;
            upgradeSpeedText.text = " куплено".ToString();
            speedButtonBuy.interactable = false;
            buttonSpeed.Interactable = false;
        }
    }

    public void UpgradeJump()
    {
        if (player.CoinAmount >= praceUpgradeJump)
        {
            player.JumpForce += upgradeJump;
            player.CoinAmount -= praceUpgradeJump;
            amountUpgradeJump += 1;
            upgradeJumpText.text = " куплено".ToString();
            jumpButtonBuy.interactable = false;
            buttonJump.Interactable = false;
        }
    }

    public void ExitTheShop()
    {
        this.gameObject.SetActive(false);
        shopButton.SetActive(true);
        Time.timeScale = 1f;
    }
}
