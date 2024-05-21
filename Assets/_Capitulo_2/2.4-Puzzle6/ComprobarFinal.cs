using UnityEngine;
using UnityEngine.SceneManagement;

public class ComprobarFinal : MonoBehaviour
{
    public Fallar failscript;

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    private AudioManager musicManager;

    void Start()
    {
        if (Oscuro != null)
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("In");
            Invoke("apagarOscuro", 1.5f);
        }

        switch (PlayerPrefs.GetInt("SaveActual"))
        {
            case 1:
                PlayerPrefs.SetInt("Escena1", 20);
                break;
            case 2:
                PlayerPrefs.SetInt("Escena2", 20);
                break;
            case 3:
                PlayerPrefs.SetInt("Escena3", 20);
                break;
        }

        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        musicManager.Play("Puzle");
    }

    void apagarOscuro()
    {
        Oscuro.SetActive(false);
    }


    public void comprobar()
    {
        if (Selector.seleccionCorrecta)
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("Out");
            Invoke("Esperar4Segundos", 1.5f);
        }
        else
        {
            Debug.Log("Selección incorrecta.");
            failscript.fail();
        }
    }

    void Esperar4Segundos()
    {
        OscuroEnd.SetActive(true);
        SceneManager.LoadScene("_Capitulo_2/2.8-Puzzle7/Info");
    }
}
