using System.Collections;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public float speed = 1f; 
    public float maxX = 1f;
    public float minX = -1f; 

    private Rigidbody2D rb;
    private bool movingRight = false;
    
    
    private float interval = 0.7f;
    public AudioSource steps;
    public Transform playerTransform;
    private float maxVolDist = 10f;
    private float minVolDist = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PlaySteps());
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
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
            if (transform.position.x < minX + speed * Time.deltaTime)
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

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        float volume = 0f;
        if (distance < minVolDist)
        {
            volume = 1f; // Max volume when player is within minVolumeDistance
        }
        else if (distance < maxVolDist)
        {
            volume = 1f - Mathf.InverseLerp(minVolDist, maxVolDist, distance); // Linearly interpolate volume between 1 and 0
        }

        // Set the volume of the audio source
        steps.volume = volume;
    }

    IEnumerator PlaySteps()
    {
        while (true)
        {
            steps.Play();
            yield return new WaitForSeconds(interval);
        }
    }
}
