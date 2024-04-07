using UnityEngine;

public class finishScript : MonoBehaviour
{
    public int coinCount = 4;

    void Start()
    {
        gameObject.SetActive(false); // Dezaktywuj obiekt na początku
    }

    void Update()
    {
        Debug.Log(coinCount);

        if (coinCount == 0)
        {
            gameObject.SetActive(true); // Aktywuj obiekt gdy coinCount wynosi 0
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
