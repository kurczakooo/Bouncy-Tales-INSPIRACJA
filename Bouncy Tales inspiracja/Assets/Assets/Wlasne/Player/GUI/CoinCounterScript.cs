using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class CoinCounterScript : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    public finishScript finishScript;
    private int maxCoins;

    void Start()
    {
        // Przypisz komponent TextMeshPro z obiektu, na którym jest ten skrypt
        textMeshPro = GetComponent<TextMeshProUGUI>();
        maxCoins = GetCoinCount();
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
    }

    void Update()
    {
        // Upewnij się, że textMeshPro nie jest nullem przed próbą jego użycia
        if (textMeshPro != null)
        {
            int currentCoins = ((GetCoinCount() - maxCoins) * -1);
            textMeshPro.text = currentCoins + "/" + maxCoins;
        }
    }

    int GetCoinCount()
    {
        return finishScript.coinCount;
    }
}
