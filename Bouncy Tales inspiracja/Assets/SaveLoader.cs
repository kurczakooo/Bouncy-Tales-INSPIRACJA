using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoader : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("Uruchomiono");

        if(SaveSytem.LoadPlayer() == null)
        {
            SaveSytem.EraseProgress();
        }
        else
        {
            bool[] lvlCompleted = SaveSytem.LoadPlayer().level;

            for (int i = 0; i < lvlCompleted.Length; i++)
            {
                switch (i)
                {
                    case 2:
                        if (lvlCompleted[i])
                        {
                            Image btnColor = transform.Find("Tutorial").GetComponent<Button>().image;
                            btnColor.color = new Color(0.970f, 0.744f, 0.00f, 1.0f);
                            transform.Find("Tutorial").GetComponent<Button>().image = btnColor;
                        }
                        break;
                    case 3:
                        if (lvlCompleted[i])
                        {
                            Image btnColor = transform.Find("Level_1").GetComponent<Button>().image;
                            btnColor.color = new Color(0.970f, 0.744f, 0.00f, 1.0f);
                            transform.Find("Level_1").GetComponent<Button>().image = btnColor;
                        }
                        break;
                    case 4:
                        if (lvlCompleted[i])
                        {
                            Image btnColor = transform.Find("Level_2").GetComponent<Button>().image;
                            btnColor.color = new Color(0.970f, 0.744f, 0.00f, 1.0f);
                            transform.Find("Level_2").GetComponent<Button>().image = btnColor;
                        }
                        break;
                    case 5:
                        if (lvlCompleted[i])
                        {
                            Image btnColor = transform.Find("Level_3").GetComponent<Button>().image;
                            btnColor.color = new Color(0.970f, 0.744f, 0.00f, 1.0f);
                            transform.Find("Level_3").GetComponent<Button>().image = btnColor;
                        }
                        break;
                }
            }

            Debug.Log("scene index 0 " + lvlCompleted[0]);
            Debug.Log("scene index 1 " + lvlCompleted[1]);
            Debug.Log("scene index 2 " + lvlCompleted[2]);
            Debug.Log("scene index 3 " + lvlCompleted[3]);
            Debug.Log("scene index 4 " + lvlCompleted[4]);
            Debug.Log("scene index 5 " + lvlCompleted[5]);
        }
        
    }

}
