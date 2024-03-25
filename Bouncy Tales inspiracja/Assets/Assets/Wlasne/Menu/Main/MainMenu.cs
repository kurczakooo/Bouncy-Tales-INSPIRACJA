using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play button in main menu
    public void PlayGame() {
        
       // SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("ChooseLevel");

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
