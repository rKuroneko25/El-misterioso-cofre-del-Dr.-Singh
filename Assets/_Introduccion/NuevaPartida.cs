using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NuevaPartida : MonoBehaviour
{

    public void NuevaPartida1()
    {
        PlayerPrefs.SetInt("Save1", 1);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        SceneManager.LoadScene("_Capitulo_1/1.0-Intro/Escena");
    }

    public void NuevaPartida2()
    {
        PlayerPrefs.SetInt("Save2", 1);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        SceneManager.LoadScene("_Capitulo_1/1.0-Intro/Escena");
    }

    public void NuevaPartida3()
    {
        PlayerPrefs.SetInt("Save3", 1);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        SceneManager.LoadScene("_Capitulo_1/1.0-Intro/Escena");
    }
}
