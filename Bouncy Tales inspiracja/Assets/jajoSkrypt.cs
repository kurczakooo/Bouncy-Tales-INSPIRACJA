using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JajoScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public Transform groundCheck; // Uziemienie
    public LayerMask groundLayer; // Warstwa uziemienia

    private bool isGrounded;
    // TEST
    void Start()
    {
        //body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGrounded();
        MoveBall();
        Jump();
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void MoveBall()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        body.velocity = new Vector2(movement.x * moveSpeed, body.velocity.y);
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("SKACZE");
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
}
