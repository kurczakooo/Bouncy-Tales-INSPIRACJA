using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JajoScript : MonoBehaviour
{
    public Canvas DeathUI;

    public static int playerHealth = 10;

    public Rigidbody2D body;
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    private float lowerJumpHeight = 3.5f;
    public Transform groundCheck; // Uziemienie
    public LayerMask groundLayer; // Warstwa uziemienia
    public AudioSource jumpSound; // Komponent AudioSource dla dźwięku skoku
    public AudioSource loseHP;
    public AudioSource level_music;
    public HealthScriptGui healthScriptGui;

    private bool isGrounded;
    private CircleCollider2D circleCollider; // Komponent CircleCollider2D ko?a

    public bool doubleJump = false;

    void Start()
    {
        SoundManager.SetMasterVolume(SoundManager.masterVolume);

        int id = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(id);

        body = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>(); // Pobierz CircleCollider2D
        DeathUI.enabled = false;
    }


    void Update()
    {
        CheckGrounded();
        MoveBall();
        Jump();
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
            // Check if the ball is on a slope or on the edge
            if (!IsOnSlope() && !IsOnEdge())
            {
                // If not on a slope or edge, perform normal jump
                if (jumpSound != null)
                {
                    jumpSound.Play();
                }

                body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
            else
            {
                // If on a slope or edge, perform lower jump
                if (jumpSound != null)
                {
                    jumpSound.Play();
                }

                body.AddForce(Vector2.up * lowerJumpHeight, ForceMode2D.Impulse);
            }
        }
        else if (!isGrounded && Input.GetKeyDown(KeyCode.UpArrow) && doubleJump == true)
        {
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            doubleJump = false;
        }
    }

    bool IsOnSlope()
    {
        // Cast a ray downward to detect if the ball is on a slope
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // Check if the hit collider is not null and the angle of the surface is greater than a threshold
        if (hit.collider != null && Mathf.Abs(hit.normal.y) < 0.9f)
        {
            return true;
        }

        return false;
    }

    bool IsOnEdge()
    {
        // Cast a ray downward to detect if the ball is on the edge
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // Check if the hit collider is null
        if (hit.collider == null)
        {
            return true;
        }

        return false;
    }



    // When our collider2D touches other 2D collider with tag "Enemy", we die
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (loseHP != null)
            {
                loseHP.Play();
            }
            PlayerGotHit(1);
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            PlayerGotHit(10);
        }
    }


    private void PlayerGotHit(int amount)
    {
        playerHealth -= amount;
        ShouldDie();
    }


    private bool ShouldDie()
    {
        if (playerHealth <= 0)
        {
            if (healthScriptGui.die != null)
            {
                level_music.Stop();
                healthScriptGui.die.Play();
                Debug.Log("YOU DIED");
            }
            Death();
            return true;
        }
        return false;
    }

    private void Death()
    {
        playerHealth = 0;
        gameObject.SetActive(false);
        DeathUI.enabled = true;
    }
}
