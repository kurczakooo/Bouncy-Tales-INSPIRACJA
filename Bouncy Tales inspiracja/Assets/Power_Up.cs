using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Power_Up : MonoBehaviour
{

    public JajoScript player; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!player.doubleJump)
            this.GetComponent<AudioSource>().Play();
        Debug.Log(player.doubleJump);
        player.doubleJump = true;
        Debug.Log(player.doubleJump);
    }

    // Changing transparency of item 
    private void Update()
    {
        if(player.doubleJump)
        {
            Color currentColor = this.GetComponent<SpriteRenderer>().color;
            currentColor.a = 0.5f;
            this.GetComponent<SpriteRenderer>().color = currentColor;
        }
        else
        {
            Color currentColor = this.GetComponent<SpriteRenderer>().color;
            currentColor.a = 1.0f;
            this.GetComponent<SpriteRenderer>().color = currentColor;
        }
    }


}
