using UnityEngine;
using UnityEngine.SceneManagement;

public class cutreasfuck3 : MonoBehaviour
{
    void Start()
    {
        Invoke("Esperar4Segundos", 7);
    }

    void Esperar4Segundos()
    {
        SceneManager.LoadScene("_Capitulo_1/1.3-Dialogo/Escena");
    }
}
