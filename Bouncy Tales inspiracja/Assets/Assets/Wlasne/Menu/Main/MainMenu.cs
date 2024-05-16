using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
    }
    // Play button in main menu
    public void PlayGame() {
        SceneDude.LoadScene("ChooseLevel");
        // SceneManager.LoadScene("ChooseLevel");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame() {
        Debug.Log("Quiting!");
        Application.Quit();
    }

    public void EraseProgress()
    {
        SaveSytem.EraseProgress();
    }
}
