using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitlePanel : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
