using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play button in main menu
    public void PlayGame() {
        SceneLoader.LoadScene("Tutorial Level");
        // SceneManager.LoadScene("ChooseLevel");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame() {
        Debug.Log("Quiting!");
        Application.Quit();
    }
}
