﻿using System;
using UnityEngine;

public class finishScript : MonoBehaviour
{
    public int coinCount = 4;
    public GameObject Flaga;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (coinCount == 0)
        {
             Flaga.SetActive(true); // Aktywuj obiekt gdy coinCount wynosi 0
        }
        else
        {
            Flaga.SetActive(false); // Dezaktywuj obiekt na początku
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Przeszedles LEVEL");
        }
    }
}
