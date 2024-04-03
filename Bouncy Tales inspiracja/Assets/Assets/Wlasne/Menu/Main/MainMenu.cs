using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play button in main menu
    public void PlayGame() {
        
        SceneManager.LoadScene("Level_1");
        // SceneManager.LoadScene("ChooseLevel");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


    // Quits game xd
    public void QuitGame() {
        Debug.Log("Quiting!");
        Application.Quit();
    }

}
