using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonesCiudades : MonoBehaviour
{
    private static GameObject BotonSeleccionado = null;
    public Fallar failScript;
    public GameObject Dialogo;

    public GameObject Amelia;

    private AudioManager musicManager;
    private string musicaActiva;

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    // Start is called before the first frame update
    void Start()
    {
        BotonSeleccionado = null;

        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        musicaActiva = musicManager.GetCurrentPlayingSong();
        musicManager.Stop(musicaActiva);
        musicManager.Play("Puzle");

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

    void SeleccionaBoton(GameObject boton)
    {
        //cambia la opacidad de la imagen del boton
        if (BotonSeleccionado != null)
        {
            Color color1 = BotonSeleccionado.GetComponent<Image>().color;
            color1.a = 0;
            BotonSeleccionado.GetComponent<Image>().color = color1;
        }
        Color color = boton.GetComponent<Image>().color;
        color.a = 0.5f;
        boton.GetComponent<Image>().color = color;
        BotonSeleccionado = boton;
    }

    public void BotonBristol()
    {
        SeleccionaBoton(gameObject);
        Debug.Log("Bristol");
    }
    public void BotonLondres()
    {
        SeleccionaBoton(gameObject);
        Debug.Log("Londres");
    }
    public void BotonMan()
    {
        SeleccionaBoton(gameObject);
        Debug.Log("Man");
    }
    public void BotonBirmingham()
    {
        SeleccionaBoton(gameObject);
        Debug.Log("Birmingham");
    }

    public void Resolver()
    {
        if (BotonSeleccionado == null)
        {
            Debug.Log("No has seleccionado ninguna ciudad");
            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(0);
            Invoke("DesactivarDialogo", 3.0f);

        }
        if (BotonSeleccionado.name != "Bristol")
        {
            // que ponga el audio de no creo que sea esa
            Debug.Log("No creo que sea esa");
            failScript.fail();
        }
        else
        {
            Debug.Log("Puzzle resuelto");
            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(2);

            Amelia.GetComponent<AudioSource>().clip = Resources.Load("Voces/8_Puzle3/Puzle3_Amelia5") as AudioClip;
            Amelia.GetComponent<AudioSource>().Play();

            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("Out");
            Invoke("CargarEscena", 2.0f);
        }
    }

    public void CargarEscena()
    {
        OscuroEnd.SetActive(true);
        SceneManager.LoadScene("_Capitulo_1/1.7-Dialogo/Escena");
    }

    public void DesactivarDialogo()
    {
        Dialogo.SetActive(false);
    }
}