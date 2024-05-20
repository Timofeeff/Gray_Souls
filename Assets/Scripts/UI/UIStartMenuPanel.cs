using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartMenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private UIButton continueButton;
    private int level;

    private void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        if (level <= 1)
            continueButton.Interactable = false;
        else
            continueButton.Interactable = true;
    }

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

    public void ActivateStoryPanel()
    {
        this.gameObject.SetActive(false);
        storyPanel.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void ActivateSettingsPanel()
    {
        this.gameObject.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}