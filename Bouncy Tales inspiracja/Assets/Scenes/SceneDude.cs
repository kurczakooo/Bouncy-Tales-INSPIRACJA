using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneDude : MonoBehaviour
{
    // Menu + Choose lvl
    public static int notLevelScenes = 2;

    // To use in other scripts type: SceneLoader.LoadScene("Scene name")
    public static void LoadScene(string sceneName) {

        if(string.IsNullOrEmpty(sceneName)){
            throw new System.ArgumentException("Nazwa sceny jest pusta, lub null");
        }

        try {
            SceneManager.LoadScene(sceneName);
        }
        catch (System.Exception ex) {
            Debug.LogError($"Błąd ładowania sceny: {sceneName}. Error msg: " + ex.Message);
        }
    }

    // If nothing passed as an argument, offset's value will be 1
    public static void LoadNextScene(int offset = 1) {

        try {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+offset);
        }
        catch (System.Exception ex) {
            Debug.LogError($"Błąd ładowania nastepnej sceny" +
                           $". Error msg:  + {ex.Message}");
        }
    }

    public static void LoadMenu()
    {
        try
        {
            SceneManager.LoadScene("MainMenu");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Błąd ładowania nastepnej sceny. Error msg: {ex.Message}");
        }
    }




    public static void Play(){  
        LoadScene("Choose Level");
    }

    // Returns number of all scenes in project which are checked in Build settings
    public static int GetNumerOfAllScenesInBuild() {
        return SceneManager.sceneCountInBuildSettings;
    }   

    // All scenes must be checked in Build setting, otherwise it shant work
    public static int GetNumerOfAllLevelScenesInBuild() {
        return SceneManager.sceneCountInBuildSettings - notLevelScenes;
    }   
}
