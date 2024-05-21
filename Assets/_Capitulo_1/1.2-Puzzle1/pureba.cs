using UnityEngine;
using UnityEngine.SceneManagement;

public class pureba : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Singh;
    public GameObject Amelia;
    public GameObject Dialogo;

    static bool boton1;
    static bool boton2;

    private AudioManager musicManager;
    private string musicaActiva;

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    void Start()
    {
        Oscuro.SetActive(true);
        Oscuro.GetComponent<Animator>().SetTrigger("In");
        Invoke("apagarOscuro", 1.5f);

        boton1 = true;
        boton2 = false;

        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        musicaActiva = musicManager.GetCurrentPlayingSong();
        musicManager.Stop(musicaActiva);
        musicManager.Play("Puzle");
    }

    void apagarOscuro()
    {
        Oscuro.SetActive(false);
    }

    public void clickcaja()
    {
        if (boton1)
        {
            boton1 = false;
            Debug.Log("Click en la caja");

            Amelia.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_Amelia1") as AudioClip;
            Amelia.GetComponent<AudioSource>().Play();

            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(2);

            Invoke("clickcaja2", 5.0f);
        }
    }

    public void clickcaja2()
    {
        Singh.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_DrSingh1") as AudioClip;
        Singh.GetComponent<AudioSource>().Play();

        Dialogo.GetComponent<Dialogue1_2>().escribir(0);

        Invoke("clickcaja3", 3.0f);
    }

    public void clickcaja3()
    {
        Dialogo.SetActive(false);
        boton2 = true;
    }

    public void clickNombre()
    {
        if (boton2)
        {
            boton2 = false;
            Debug.Log("Click en el Nombre ");
            Singh.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_DrSingh2") as AudioClip;
            Singh.GetComponent<AudioSource>().Play();

            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(1);

            Invoke("clickNombre2", 6.0f);
        }
    }

    public void clickNombre2()
    {
        Amelia.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_Amelia2") as AudioClip;
        Amelia.GetComponent<AudioSource>().Play();

        Dialogo.GetComponent<Dialogue1_2>().escribir(3);

        Invoke("clickNombre3", 5.0f);
    }

    public void clickNombre3()
    {
        Amelia.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_DrSingh3") as AudioClip;
        Amelia.GetComponent<AudioSource>().Play();

        Dialogo.GetComponent<Dialogue1_2>().escribir(5);

        Invoke("clickNombre4", 3.0f);
    }

    public void clickNombre4()
    {
        Dialogo.SetActive(false);
    }

    public void resolver()
    {
        if (boton1 || boton2)
        {
            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(4);
        }
        else
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("Out");
            Invoke("Esperar4Segundos", 1.5f);
        }
    }

    void Esperar4Segundos()
    {
        OscuroEnd.SetActive(true);
        SceneManager.LoadScene("_Capitulo_1/1.2-Puzzle1/Info");
    }
}
