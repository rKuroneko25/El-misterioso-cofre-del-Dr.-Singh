using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Giratubería : MonoBehaviour
{
    public int position;
    public int posicionCorrecta;
    private Animator animator;
    private AudioManager2 audioManager;

    static int tuberiasCorrectas = 0;
    static int manivelaOK = 0;

    public Fallar failscript;

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    private AudioManager musicManager;

    // Start is called before the first frame update
    void Start()
    {

        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        musicManager.Play("Puzle");

        animator = GetComponent<Animator>();

        switch (PlayerPrefs.GetInt("SaveActual"))
        {
            case 1:
                PlayerPrefs.SetInt("Escena1", 19);
                break;
            case 2:
                PlayerPrefs.SetInt("Escena2", 19);
                break;
            case 3:
                PlayerPrefs.SetInt("Escena3", 19);
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (tuberiasCorrectas < 5 && gameObject.tag == "Tuberia")
            {
                // Obtenemos el rayo desde la cámara al punto donde hicimos clic
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 5.0f);
                // Si el rayo golpea al GameObject
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == null)
                {
                    Debug.Log("rayo colisiona con" + hit.collider.gameObject.name);

                }
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Tuberia clickeada");
                    // Activamos el trigger de la animación
                    position = (position + 1) % 4;
                    // lanza la funcion triggerAnimation
                    StartCoroutine(triggerAnimationTub());
                    if (position == posicionCorrecta)
                    {
                        tuberiasCorrectas++;
                        GetComponent<BoxCollider>().enabled = false;
                        if (tuberiasCorrectas == 5)
                        {
                            Debug.Log("Tuberias colocadas correctamente");
                        }
                    }
                }
            }
            else
            {
                if (tuberiasCorrectas == 5 && gameObject.tag == "Manivela" && manivelaOK == 0)
                {
                    StartCoroutine(triggerAnimationManivela());
                    GetComponent<BoxCollider>().enabled = false;
                    Debug.Log("Manivela girada, Puzzle completado");
                    manivelaOK = 1;
                }
            }

        }
    }

    IEnumerator triggerAnimationManivela()
    {
        audioManager = FindObjectOfType<AudioManager2>();
        animator.SetTrigger("giraManivela");
        Debug.Log("Sonido de valvula");
        audioManager.Play("valvula");
        yield return new WaitForSeconds(1.5f);
        animator.ResetTrigger("giraManivela");
        Debug.Log("Sonido de agua");
        audioManager.Play("agua");
    }

    IEnumerator triggerAnimationTub()
    {
        audioManager = FindObjectOfType<AudioManager2>();
        animator.SetTrigger("rot" + position.ToString());
        audioManager.Play("tuberia");
        yield return new WaitForSeconds(1.0f);
        animator.ResetTrigger("rot" + position.ToString());
    }

    public void resolver()
    {
        if (tuberiasCorrectas == 5 && manivelaOK == 1)
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
        SceneManager.LoadScene("_Capitulo_2/2.4-Puzzle6/Info");
    }
}
