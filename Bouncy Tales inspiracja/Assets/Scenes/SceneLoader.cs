using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    // To use in other scripts type: SceneLoader.LoadScene("Scene name")
    public static void LoadScene(string sceneName) {

        if(string.IsNullOrEmpty(sceneName)){
            throw new System.ArgumentException("Nazwa sceny jest pusta, lub null");
        }

        try{
            SceneManager.LoadScene(sceneName);
        }
        catch (System.Exception ex){
            Debug.LogError("Błąd ładowania sceny: " + ex.Message);
        }
    }
}
