using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CajitaTexto : MonoBehaviour
{
    public Botones Botones;

    public GameObject Bloqueo;

    public TextMeshProUGUI nameComponent;       //Asociar al título
    public TextMeshProUGUI textComponent;       //Asociar al texto
    public string nombre;                       //Nombre que aparece en la caja
    public string[] textLines;                  //Vector de diálogos
    public int nLines;                          //Número de líneas de diálogo
    private int index;                          //Índice de diálogo

    private float textSpeed = 0.01f;

    private bool maninRelajate;

    private Coroutine RefTypeLine;     //Referencia a la corrutina de escribir

    private AudioManager musicManager;
    private AudioManager2 sfxManager;


    void Start()
    {
        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        sfxManager = GameObject.Find("AudioManager (SFX)").GetComponent<AudioManager2>();

        musicManager.Stop(musicManager.GetCurrentPlayingSong());
        musicManager.Play("Libre");
        switch (PlayerPrefs.GetInt("SaveActual"))
        {
            case 1:
                PlayerPrefs.SetInt("Escena1", 7);
                break;
            case 2:
                PlayerPrefs.SetInt("Escena2", 7);
                break;
            case 3:
                PlayerPrefs.SetInt("Escena3", 7);
                break;
        }
    }

    void OnEnable()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Aparece");
        nameComponent.text = string.Empty;
        textComponent.text = string.Empty;
        index = 0;
        maninRelajate = false;
        StartCoroutine(PrimerTexto());
    }

    void Update()
    {
        sfxManager.Volume(PlayerPrefs.GetFloat("VolumenSFX"));
        musicManager.Volume(PlayerPrefs.GetFloat("VolumenMusica"));
        if (!maninRelajate) {
            if(Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == textLines[index])
                {
                    NextLine();
                }
                else
                {
                    StopCoroutine(RefTypeLine);
                    textComponent.text = textLines[index];
                    if (sfxManager.IsPlaying("TypingText")) {
                        sfxManager.Stop("TypingText");
                    }
                }
            }
        }
    }

    void NextLine()
    {
        if (index < nLines-1)
        {
            index++;
            StartCoroutine(Texto());
        }
        else
        {
            StartCoroutine(Finalizar());
        }
    } 

    IEnumerator PrimerTexto()
    {
        yield return new WaitForSeconds(1f);
        // GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); no hace nada
        StartCoroutine(Texto());
    }

    IEnumerator Texto()
    {
        sfxManager.Play("TypingText");
        nameComponent.text = nombre;
        textComponent.text = string.Empty;
        RefTypeLine = StartCoroutine(TypeLine());
        yield return null;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in textLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if (sfxManager.IsPlaying("TypingText")) {
            sfxManager.Stop("TypingText");
        }
    }

    IEnumerator Finalizar()
    {
        textComponent.text = string.Empty;
        nameComponent.text = string.Empty;
        gameObject.GetComponent<Animator>().SetTrigger("Desaparece");

        yield return new WaitForSeconds(1.0f);

        GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

        Bloqueo.SetActive(false);

        if (textLines[1] == "Debería de volver ya con el Doctor.") {
            Botones.exit = true;
        }

        gameObject.SetActive(false);
    }
}
