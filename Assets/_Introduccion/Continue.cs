using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    private int Escena;

    public void Continue1()
    {
        Escena = PlayerPrefs.GetInt("Escena1");
        PlayerPrefs.SetInt("SaveActual", 1);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        SceneManager.LoadScene(MegaSwitch(Escena));
    }

    public void Continue2()
    {
        Escena = PlayerPrefs.GetInt("Escena2");
        PlayerPrefs.SetInt("SaveActual", 2);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        SceneManager.LoadScene(MegaSwitch(Escena));
    }

    public void Continue3()
    {
        Escena = PlayerPrefs.GetInt("Escena3");
        PlayerPrefs.SetInt("SaveActual", 3);
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        SceneManager.LoadScene(MegaSwitch(Escena));
    }

    string MegaSwitch(int Escena)
    {
        switch (Escena)
        {
            case 0:
                return "_Capitulo_1/1.0-Intro/Escena";
            case 1:
                return "_Capitulo_1/1.1-Dialogo/Escena";
            case 2:
                return "_Capitulo_1/1.1-Dialogo/Escena_2";
            case 3:
                return "_Capitulo_1/1.1-Dialogo/Escena_3";
            case 4:
                return "_Capitulo_1/1.1-Dialogo/Escena_4";
            case 6:
                return "_Capitulo_1/1.1-Dialogo/Escena_4_2";
            case 7:
                return "_Capitulo_1/1.1.5-Libre/Escena";
            case 8:
                return "_Capitulo_1/1.2-Puzzle1/Puzzle1";
            case 9:
                return "_Capitulo_1/1.3-Dialogo/Escena";
            case 10:
                return "_Capitulo_1/1.4-Puzzle2/Puzzle2";
            case 11:
                return "_Capitulo_1/1.5-Dialogo/Escena";
            case 12:
                return "_Capitulo_1/1.6-Puzzle3/Puzzle3";
            case 13:
                return "_Capitulo_1/1.7-Dialogo/Escena";
            case 14:
                return "_Capitulo_1/1.7-Dialogo/Escena_2";
            case 15:
                return "_Capitulo_1/1.8-Puzzle4/Puzzle4";
            case 16:
                return "_Capitulo_1/1.9-Dialogo/Escena";
            case 17:
                return "_Capitulo_1/1.9-Dialogo/Escena_1";
            case 18:
                return "_Capitulo_1/1.9-Dialogo/Escena_2";
            case 19:
                return "_Capitulo_2/2.2-Puzzle5/Puzzle5";
            case 20:
                return "_Capitulo_2/2.4-Puzzle6/Puzzle6";
            case 21:
                return "_Capitulo_2/2.8-Puzzle7/Puzzle7";
            case 22:
                return "_Capitulo_2/2.13-Puzzle8/Puzzle8";
            default:
                return "_Capitulo_1/1.1-Dialogo/Escena";
        }
    }
}
