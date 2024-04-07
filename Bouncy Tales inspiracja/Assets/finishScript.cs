using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishScript : MonoBehaviour
{
    public int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coinCount <= 1)
        {
            gameObject.SetActive(true);  
        }
        else
        {
            gameObject.SetActive(false);
        }

        Debug.Log(coinCount.ToString() +  gameObject.activeSelf.ToString());
        
    }
}
