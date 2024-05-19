using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comprobar : MonoBehaviour
{
    public Fallar failScript;

    public void ReadString(string s)
    {
        if (s == "426")
        {
            SceneManager.LoadScene("_Capitulo_1/1.9-Dialogo/Escena");
        }
        else
        {
            failScript.fail();
        }
    }
}
