using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mamawebo2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("SaveActual"))
        {
            case 1:
                PlayerPrefs.SetInt("Escena1", 10);
                break;
            case 2:
                PlayerPrefs.SetInt("Escena2", 10);
                break;
            case 3:
                PlayerPrefs.SetInt("Escena3", 10);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
