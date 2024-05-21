using UnityEngine;
using UnityEngine.SceneManagement;

public class NuevaPartida : MonoBehaviour
{

    public void NuevaPartida1()
    {
        PlayerPrefs.SetInt("Save1", 1);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        PlayerPrefs.SetInt("Escena1",0);
        PlayerPrefs.SetInt("SaveActual", 1);
        SceneManager.LoadScene("_Capitulo_1/1.0-Intro/Escena");
    }

    public void NuevaPartida2()
    {
        PlayerPrefs.SetInt("Save2", 1);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        PlayerPrefs.SetInt("Escena2",0);
        PlayerPrefs.SetInt("SaveActual", 2);
        SceneManager.LoadScene("_Capitulo_1/1.0-Intro/Escena");
    }

    public void NuevaPartida3()
    {
        PlayerPrefs.SetInt("Save3", 1);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        PlayerPrefs.SetInt("Escena3",0);
        PlayerPrefs.SetInt("SaveActual", 3);
        SceneManager.LoadScene("_Capitulo_1/1.0-Intro/Escena");
    }
}
