using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mamawebo3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("SaveActual"))
        {
            case 1:
                PlayerPrefs.SetInt("Escena1", 15);
                break;
            case 2:
                PlayerPrefs.SetInt("Escena2", 15);
                break;
            case 3:
                PlayerPrefs.SetInt("Escena3", 15);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
