using UnityEngine;
using UnityEngine.UI;

public class MessagePillar : MonoBehaviour
{
    [SerializeField] private GameObject message;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        message.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        message.SetActive(false);
    }
}
