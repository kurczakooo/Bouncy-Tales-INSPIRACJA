using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // Length must be number of scenes + 1
    public bool[] level = new bool[6];
   
    public PlayerData(int sceneIndex)
    {
        level[sceneIndex] = true;
    }

}
