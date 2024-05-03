using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutreasfuck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Esperar35Segundos", 35);
    }

    void Esperar35Segundos()
    {
        SceneManager.LoadScene("_Capitulo_1/1.1-Dialogo/Escena");
    }

}
