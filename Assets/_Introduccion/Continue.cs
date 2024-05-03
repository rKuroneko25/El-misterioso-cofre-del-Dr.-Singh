using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    private int Escena;

    public void Continue1()
    {
        Escena = PlayerPrefs.GetInt("Escena1");
        SceneManager.LoadScene(MegaSwitch(Escena));
    }

    public void Continue2()
    {
        Escena = PlayerPrefs.GetInt("Escena2");
        SceneManager.LoadScene(MegaSwitch(Escena));
    }

    public void Continue3()
    {
        Escena = PlayerPrefs.GetInt("Escena3");
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
                return "_Capitulo_1/1.1.5-Libre/Escena";
            case 3:
                return "_Capitulo_1/1.2-Puzzle1/Puzzle1";
            case 4:
                return "_Capitulo_1/1.3-Dialogo/Escena";
            case 5:
                return "_Capitulo_1/1.4-Puzzle2/Puzzle2";
            case 6:
                return "_Capitulo_1/1.5-Dialogo/Escena";
            case 7:
                return "_Capitulo_1/1.6-Puzzle3/Puzzle3";
            case 8:
                return "_Capitulo_1/1.7-Dialogo/Escena";
            case 9:
                return "_Capitulo_1/1.8-Puzzle4/Puzzle4";
            case 10:
                return "_Capitulo_1/1.9-Dialogo/Escena";
            default:
                return "_Capitulo_1/1.1-Dialogo/Escena";
        }
    }
}
