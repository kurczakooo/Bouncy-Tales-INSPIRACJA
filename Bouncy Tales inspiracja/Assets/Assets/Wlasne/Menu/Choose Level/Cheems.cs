using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cheems : MonoBehaviour
{
    public float rotationSpeed = 30f; // Szybkość obrotu
    public float movementSpeed; // Szybkość przesuwania
    private bool movingRight = true; // Czy obiekt przesuwa się w prawo

    private void Start()
    {
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
    }

    void FixedUpdate()
    {
        // Obrót obiektu wokół osi Y
        transform.Rotate(0.0f, 0.0f, 2.0f * rotationSpeed * Time.deltaTime);

        // Przesunięcie obiektu w prawo i lewo
        if (movingRight)
        {
            transform.Translate(Vector3.right* movementSpeed*Time.deltaTime, Space.World);
            if (transform.position.x >= 14.0f)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime, Space.World);
            if (transform.position.x <= -18.0f)
            {
                movingRight = true;
            }
        }
    }
}
