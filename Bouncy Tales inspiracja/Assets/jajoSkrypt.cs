using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JajoSkrypt : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed = 5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveBall();
    }

    void MoveBall()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        body.velocity = new Vector2(body.velocity.x, movement.x * moveSpeed);
    }
}
