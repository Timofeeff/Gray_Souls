using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStoryPanel : MonoBehaviour
{
    [SerializeField] private GameObject startMenuPanel;

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteKey("Level");
        PlayerPrefs.DeleteKey("CoinAmount");
        PlayerPrefs.DeleteKey("Attack");
        PlayerPrefs.DeleteKey("Speed");
        PlayerPrefs.DeleteKey("JumpForce");
        PlayerPrefs.DeleteKey("amountAttack");
        PlayerPrefs.DeleteKey("amountSpeed");
        PlayerPrefs.DeleteKey("amountJump");
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void ReturnToMenu()
    {
        this.gameObject.SetActive(false);
        startMenuPanel.SetActive(true);
    }
}
