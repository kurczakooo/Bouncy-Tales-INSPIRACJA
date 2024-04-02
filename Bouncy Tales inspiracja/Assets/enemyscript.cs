using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float maxLeft = -1.0f;
    public float maxRight = 1.0f;

    private bool moveRight = true;

    void Update()
    {
        if (moveRight && transform.position.x < maxRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (!moveRight && transform.position.x > maxLeft)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= maxRight)
        {
            moveRight = false;
        }
        else if (transform.position.x <= maxLeft)
        {
            moveRight = true;
        }
    }
}
