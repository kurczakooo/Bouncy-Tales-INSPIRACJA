using UnityEngine;

public class playerscript : MonoBehaviour
{
    public float speed = 1f; 
    public float maxX = 1f;
    public float minX = -1f; 

    private Rigidbody2D rb;
    private bool movingRight = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            if (transform.position.x >= maxX - speed * Time.deltaTime)
            {
                Flip();
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        else
        {
            if (transform.position.x <= minX + speed * Time.deltaTime)
            {
                Flip();
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }

    void Flip()
    { 
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
