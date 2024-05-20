using UnityEngine;

public class UIPause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClick();
    }

    public void OnClick()
    {
        pausePanel.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void OnReturnGame()
    {
        pausePanel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
