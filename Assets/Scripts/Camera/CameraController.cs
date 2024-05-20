using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos; 

    private void Awake()
    {
        if (!player) 
            player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        pos = player.position;
        pos.x += 1f;
        pos.z = -10f; 
        pos.y += 2.1f;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
