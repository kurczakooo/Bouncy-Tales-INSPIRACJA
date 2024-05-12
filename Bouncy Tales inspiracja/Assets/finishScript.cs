using System;
using UnityEngine;

public class finishScript : MonoBehaviour
{
    public int coinCount = 4;
    public GameObject Flaga;
    public AudioSource pickUpCoinSound;

    private void Start()
    {
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
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
}
