using UnityEngine;

public class UISettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject startMenuPanel;

    public void ReturnToMenu()
    {
        this.gameObject.SetActive(false);
        startMenuPanel.SetActive(true);
    }
}
