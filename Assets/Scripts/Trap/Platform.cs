using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    private bool movingRight;

    private void FixedUpdate()
    {
        if (transform.position.x > rightEdge.position.x)
            movingRight = false;
        if (transform.position.x < leftEdge.position.x)
            movingRight = true;

        if (movingRight)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
