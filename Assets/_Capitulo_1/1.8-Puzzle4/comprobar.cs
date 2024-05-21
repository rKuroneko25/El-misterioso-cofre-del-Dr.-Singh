using UnityEngine;
using UnityEngine.SceneManagement;

public class comprobar : MonoBehaviour
{
    public Fallar failScript;

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    public void ReadString(string s)
    {
        if (s == "426")
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("Out");
            Invoke("Esperar4Segundos", 1.5f);
        }
        else
        {
            failScript.fail();
        }
    }

    void Esperar4Segundos()
    {
        OscuroEnd.SetActive(true);
        SceneManager.LoadScene("_Capitulo_1/1.9-Dialogo/Escena");
    }
}
