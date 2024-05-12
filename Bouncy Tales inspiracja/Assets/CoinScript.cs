using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public finishScript finishScript;

    // Start is called before the first frame update
    private void Start()
    {
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            finishScript.pickUpCoinSound.Play();
            finishScript.coinCount--;
            Destroy(gameObject);
        }
    }
}
