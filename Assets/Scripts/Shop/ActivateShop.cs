using UnityEngine;

public class ActivateShop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    public void ToTheShop()
    {
        this.gameObject.SetActive(false);
        shopPanel.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
