using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resolucion : MonoBehaviour
{

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Resolucion"));
        gameObject.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("Resolucion");
    }

    public void ChangeResolution()
    {
        switch (gameObject.GetComponent<TMP_Dropdown>().value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                PlayerPrefs.SetInt("Resolucion", 0);
                Debug.Log("Resolucion 0");
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                PlayerPrefs.SetInt("Resolucion", 1);
                Debug.Log("Resolucion 1");
                break;
            case 2:
                Screen.SetResolution(854, 480, Screen.fullScreen);
                PlayerPrefs.SetInt("Resolucion", 2);
                Debug.Log("Resolucion 2");
                break;
        }
    }
}
