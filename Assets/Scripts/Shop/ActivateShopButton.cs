using UnityEngine;

public class ActivateShopButton : MonoBehaviour
{
    [SerializeField] private GameObject shopButton;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        shopButton.SetActive(true);
        Cursor.visible = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shopButton.SetActive(false);
        Cursor.visible = false;
    }
}
