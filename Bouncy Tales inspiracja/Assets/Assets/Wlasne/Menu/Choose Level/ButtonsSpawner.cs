using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonsSpawner : MonoBehaviour
{
    
    public List<GameObject> buttons = new List<GameObject>();
    public GameObject objekt;

    void Start()
    {
        for(int i =0 ; i< SceneDude.GetNumerOfAllLevelScenesInBuild(); i ++)
            buttons.Add(objekt);
    }
}

// To do list:
// Loading sceny by id czy cos for(..i = .....) load scene ($"Level{i}") 