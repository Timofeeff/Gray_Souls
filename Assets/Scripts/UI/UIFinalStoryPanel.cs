using UnityEngine;

public class UIFinalStoryPanel : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void ActivateTitlePanel()
    {
        this.gameObject.SetActive(false);
        titlePanel.SetActive(true);
    }
}
