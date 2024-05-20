using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    public void LoadLevel(int buildIndex) 
    {
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
