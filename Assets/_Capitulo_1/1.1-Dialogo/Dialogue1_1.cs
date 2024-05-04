using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class Dialogue1_1 : MonoBehaviour
{
    public TextMeshProUGUI nameComponent;       //Asociar al título
    public TextMeshProUGUI textComponent;       //Asociar al texto

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;              //Nombre que aparece en la caja
        public string activo;                   //Personaje que NO sale en gris ("L" o "R")
        public AudioClip speakerAudio;
        public GameObject LCharacterImage;
        public Material LCharacterMaterial;     //Expresión personaje izquierda
        public GameObject RCharacterImage;
        public Material RCharacterMaterial;     //Expresión personaje derecha
        public GameObject[] Salen;              //Personajes que salen del diálogo
        public GameObject[] Entran;             //Personajes que entran al diálogo
        [TextArea(3, 20)]
        public string dialogueText;
        public float textSpeed;
    }

    public DialogueLine[] dialogueLines;        //Vector de diálogos
    private int index;                          //Índice de diálogo

    private Animator[] SalenAnimators;          //Vector de animadores de personajes que salen (máx.2)
    private Animator[] EntranAnimators;         //Vector de animadores de personajes que entran (máx.2)

    private Coroutine RefTypeLine;              //Referencia a la corrutina de escribir

    private bool maninRelajate;                 //Si esta relajado no puede avanzar los dialogos en el delay de la animacion

    void Start()
    {
        maninRelajate = false;
        StartDialogue();
    }

    void Update()
    {
        if (!maninRelajate) {
            if(Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == dialogueLines[index].dialogueText)
                {
                    NextLine();
                }
                else
                {
                    StopCoroutine(RefTypeLine);
                    textComponent.text = dialogueLines[index].dialogueText;
                }
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        gameObject.SetActive(true);
        StartCoroutine(Dialogar());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueLines[index].dialogueText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(dialogueLines[index].textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            StartCoroutine(Dialogar());
        }
        else
        {
            StartCoroutine(Finalizar());
        }
    } 

    IEnumerator Dialogar()
    {
        maninRelajate = true;
        //Algún personaje sale del diálogo
        if (dialogueLines[index].Salen.Length > 0) {
            SalenAnimators = new Animator[dialogueLines[index].Salen.Length];
            for (int i = 0; i < dialogueLines[index].Salen.Length; i++) {
                SalenAnimators[i] = dialogueLines[index].Salen[i].GetComponent<Animator>();
            }
            foreach (Animator animator in SalenAnimators) {
                animator.SetTrigger("Salir");
            }
            yield return new WaitForSeconds(2f); //Perate que tienen que salir

            foreach (GameObject go in dialogueLines[index].Salen) { //Al salir, se desactivan
                go.SetActive(false);
            }
        }

        //Algún personaje entra al diálogo
        if (dialogueLines[index].Entran.Length > 0) {

            foreach (GameObject go in dialogueLines[index].Entran) { //Antes de entrar, se activan
                go.SetActive(true);
            }

            EntranAnimators = new Animator[dialogueLines[index].Entran.Length];
            for (int i = 0; i < dialogueLines[index].Entran.Length; i++) {
                EntranAnimators[i] = dialogueLines[index].Entran[i].GetComponent<Animator>();
            }
            foreach (Animator animator in EntranAnimators) {
                animator.SetTrigger("Entrar");
            }
            yield return new WaitForSeconds(2f); //Perate que tienen que entrar
        }
        
        maninRelajate = false;

        if (dialogueLines[index].activo != null) {
            if (dialogueLines[index].activo == "L") {
                //Desacticar Lips en el otro para que se vea la imagen completa base
                if (dialogueLines[index].RCharacterImage != null) {
                    dialogueLines[index].RCharacterImage.transform.GetChild(0).gameObject.SetActive(false);
                }
                //lipsync
                dialogueLines[index].LCharacterImage.transform.GetChild(0).gameObject.SetActive(true);
                dialogueLines[index].LCharacterImage.GetComponent<AudioSource>().clip = dialogueLines[index].speakerAudio;
                dialogueLines[index].LCharacterImage.GetComponent<AudioSource>().Play();
            } else {
                //Desacticar Lips en el otro para que se vea la imagen completa base
                if (dialogueLines[index].LCharacterImage != null) {
                    dialogueLines[index].LCharacterImage.transform.GetChild(0).gameObject.SetActive(false);
                }
                //lipsync
                dialogueLines[index].RCharacterImage.transform.GetChild(0).gameObject.SetActive(true);
                dialogueLines[index].RCharacterImage.GetComponent<AudioSource>().clip = dialogueLines[index].speakerAudio;
                dialogueLines[index].RCharacterImage.GetComponent<AudioSource>().Play();
            }
        }
        
        if (dialogueLines[index].LCharacterImage != null) {
            dialogueLines[index].LCharacterImage.GetComponent<Renderer>().material = dialogueLines[index].LCharacterMaterial; //Cambiar expresión

            Vector3 scaleL = dialogueLines[index].LCharacterImage.transform.localScale;  //Para voltear la imagen
            if (scaleL.x > 0) {
                scaleL.x *= -1;
                dialogueLines[index].LCharacterImage.transform.localScale = scaleL;
                dialogueLines[index].LCharacterImage.transform.position = new Vector3(-dialogueLines[index].LCharacterImage.transform.position.x, dialogueLines[index].LCharacterImage.transform.position.y, dialogueLines[index].LCharacterImage.transform.position.z);
            }
        }

        if (dialogueLines[index].RCharacterImage != null) {
            dialogueLines[index].RCharacterImage.GetComponent<Renderer>().material = dialogueLines[index].RCharacterMaterial; //Cambiar expresión
            
            Vector3 scaleR = dialogueLines[index].RCharacterImage.transform.localScale;
            if (scaleR.x < 0) {
                scaleR.x *= -1;
                dialogueLines[index].RCharacterImage.transform.localScale = scaleR;
                dialogueLines[index].RCharacterImage.transform.position = new Vector3(-dialogueLines[index].RCharacterImage.transform.position.x, dialogueLines[index].RCharacterImage.transform.position.y, dialogueLines[index].RCharacterImage.transform.position.z);
            }
        }

        nameComponent.text = dialogueLines[index].speakerName;
        textComponent.text = string.Empty;
        RefTypeLine = StartCoroutine(TypeLine());
        yield return null;
    }

    IEnumerator Finalizar(){
        textComponent.text = string.Empty;
        nameComponent.text = string.Empty;

        //Desactivar personajes al final del diálogo si existen con la animacion de salir
        if (dialogueLines[index].LCharacterImage != null) {
            dialogueLines[index].LCharacterImage.GetComponent<Animator>().SetTrigger("Salir");
        }
        if (dialogueLines[index].RCharacterImage != null) {
            dialogueLines[index].RCharacterImage.GetComponent<Animator>().SetTrigger("Salir");
        }

        gameObject.GetComponent<Animator>().SetTrigger("Desaparecer");

        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);

        if (dialogueLines[index].LCharacterImage != null) {
            dialogueLines[index].LCharacterImage.SetActive(false);
        }
        if (dialogueLines[index].RCharacterImage != null) {
            dialogueLines[index].RCharacterImage.SetActive(false);
        }
    }
}
