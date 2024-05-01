using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JajoScript : MonoBehaviour
{
    public Canvas DeathUI;

    public static int playerHealth = 10;

    public Rigidbody2D body;
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public Transform groundCheck; // Uziemienie
    public LayerMask groundLayer; // Warstwa uziemienia
    public AudioSource jumpSound; // Komponent AudioSource dla dźwięku skoku
    public AudioSource loseHP;

    private bool isGrounded;
    private CircleCollider2D circleCollider; // Komponent CircleCollider2D ko?a

    public bool doubleJump = false;

    void Start()
    {
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
            // Odtwórz dźwięk skoku
            if (jumpSound != null)
            {
                jumpSound.Play();
            }

            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        else if(!isGrounded && Input.GetKeyDown(KeyCode.UpArrow) && doubleJump == true)
        {
                    body.velocity = new Vector2(body.velocity.x, 0f);
                    body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    doubleJump = false;
        }
    }


    // When our collider2D touches other 2D collider with tag "Enemy", we die
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag("Enemy")){
            PlayerGotHit();
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Death();
        }
    }


    private void PlayerGotHit() {
        if (loseHP != null)
        {
            loseHP.Play();
        }
        playerHealth -= 1;
        Debug.Log("HP: " + playerHealth);
        ShouldDie();
    }


    private bool ShouldDie() {
        if (playerHealth <= 0) {
            Death();
            return true;
        }
        return false;
    }

    private void Death() {
        playerHealth = 0;
        gameObject.SetActive(false);
        DeathUI.enabled = true;
    }
/* To do: Hit sounds*/
}
