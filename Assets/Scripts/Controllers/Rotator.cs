using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
