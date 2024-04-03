using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JajoScript : MonoBehaviour
{

    public bool doubleJump = false;
    private bool jumped = false;
    public int playerHealth = 1;

    public Rigidbody2D body;
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public Transform groundCheck; // Uziemienie
    public LayerMask groundLayer; // Warstwa uziemienia

    private bool isGrounded;
    private CircleCollider2D circleCollider; // Komponent CircleCollider2D ko?a

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>(); // Pobierz CircleCollider2D
    }

    void Update()
    {
        CheckGrounded();
        MoveBall();
        Jump();
        CheckDeath();
    }

    void CheckGrounded()
    {
        // Pobierz promie? ko?a
        float radius = circleCollider.radius;

        // Ustaw pozycj? punktu GroundCheck na odleg?o?? promienia ko?a poni?ej ?rodka ko?a
        groundCheck.position = new Vector2(transform.position.x, transform.position.y - radius);

        // Sprawd?, czy punkt GroundCheck znajduje si? nad ziemi?
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
            jumped = true;
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (jumped == true && doubleJump == true)
                {
                    body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    doubleJump = false;
                    jumped = false;
                }

            }
        }
    }

    // When our collider2D touches other 2D collider with tag "Enemy", we die
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Enemy")) {
            playerHealth -= 1;
            Debug.Log("HP:" + playerHealth);
        }
    }

    private void CheckDeath() {
        if (playerHealth <= 0) {
            Debug.Log("You died");
            gameObject.SetActive(false);
        }
    }



}
