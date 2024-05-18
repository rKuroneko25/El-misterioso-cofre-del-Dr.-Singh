using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {

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
