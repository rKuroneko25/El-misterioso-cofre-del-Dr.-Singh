using UnityEngine;
using UnityEngine.SceneManagement;

public class Comprobar : MonoBehaviour
{
    public Carousel carousel; // Referencia al script Carousel

    public DraggableImage draggableImage1; // Referencia al script DraggableImage de la imagen 1ç

    public Fallar failscript;

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    private AudioManager musicManager;

    void Start()
    {
        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        musicManager.Play("Puzle");

    
        switch (PlayerPrefs.GetInt("SaveActual"))
        {
            case 1:
                PlayerPrefs.SetInt("Escena1", 22);
                break;
            case 2:
                PlayerPrefs.SetInt("Escena2", 22);
                break;
            case 3:
                PlayerPrefs.SetInt("Escena3", 22);
                break;
        }
    

        if (Oscuro != null)
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("In");
            Invoke("apagarOscuro", 1.5f);
        }
    }

    void apagarOscuro()
    {
        Oscuro.SetActive(false);
    }

    public void comprobar()
    {
        if (carousel.currentIndex == 3 &&
            draggableImage1.transform.position.x >= 536 && draggableImage1.transform.position.x <= 700 &&
            draggableImage1.transform.position.y >= 437 && draggableImage1.transform.position.y <= 616)
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("Out");
            Invoke("Esperar4Segundos", 1.5f);
        }
        else
        {
            failscript.fail();
        }
    }

    void Esperar4Segundos()
    {
        OscuroEnd.SetActive(true);
        SceneManager.LoadScene("_Capitulo_2/2.13-Puzzle8/FinDemo");
    }
}
