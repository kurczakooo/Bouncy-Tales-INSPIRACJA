using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScriptGui : MonoBehaviour
{
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update() {

        // Player cant have more hp than hearts
        if(JajoScript.playerHealth > numberOfHearts)
            JajoScript.playerHealth = numberOfHearts;
        

        int i;
        for(i = 0; i < hearts.Length; ++i){
            
            if(i < JajoScript.playerHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if(i < numberOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
