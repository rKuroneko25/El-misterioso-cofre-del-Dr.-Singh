using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Dialogue1_1 : MonoBehaviour
{
    public TextMeshProUGUI nameComponent;
    public TextMeshProUGUI textComponent;
    

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public string activo;
        public AudioClip speakerAudio;
        public GameObject LCharacterImage;
        public Material LCharacterMaterial;
        public GameObject RCharacterImage;
        public Material RCharacterMaterial;
        [TextArea(3, 20)]
        public string dialogueText;
        public float textSpeed;
    }

    public DialogueLine[] dialogueLines;

    private int index;

    void Start()
    {
        StartDialogue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogueLines[index].dialogueText)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueLines[index].dialogueText;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;

        dialogueLines[index].LCharacterImage.SetActive(true);
        dialogueLines[index].RCharacterImage.SetActive(true);

        dialogueLines[index].LCharacterImage.GetComponent<Renderer>().material = dialogueLines[index].LCharacterMaterial;
        Vector3 scaleL = dialogueLines[index].LCharacterImage.transform.localScale;
        if (scaleL.x > 0) {
            scaleL.x *= -1;
            dialogueLines[index].LCharacterImage.transform.localScale = scaleL;
            dialogueLines[index].LCharacterImage.transform.position = new Vector3(-dialogueLines[index].LCharacterImage.transform.position.x, dialogueLines[index].LCharacterImage.transform.position.y, dialogueLines[index].LCharacterImage.transform.position.z);
        }
            
        dialogueLines[index].RCharacterImage.GetComponent<Renderer>().material = dialogueLines[index].RCharacterMaterial;
        Vector3 scaleR = dialogueLines[index].RCharacterImage.transform.localScale;
        if (scaleR.x < 0) {
            scaleR.x *= -1;
            dialogueLines[index].RCharacterImage.transform.localScale = scaleR;
            dialogueLines[index].RCharacterImage.transform.position = new Vector3(-dialogueLines[index].RCharacterImage.transform.position.x, dialogueLines[index].RCharacterImage.transform.position.y, dialogueLines[index].RCharacterImage.transform.position.z);
        }

        if (dialogueLines[index].activo == "L") {
            //ocurecer
            dialogueLines[index].RCharacterImage.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            dialogueLines[index].RCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            //iluminar
            dialogueLines[index].LCharacterImage.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            dialogueLines[index].LCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            //lipsync
            dialogueLines[index].LCharacterImage.GetComponent<AudioSource>().clip = dialogueLines[index].speakerAudio;
            dialogueLines[index].LCharacterImage.GetComponent<AudioSource>().Play();
        } else {
            //oscurecer
            dialogueLines[index].LCharacterImage.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            dialogueLines[index].LCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            //iluminar
            dialogueLines[index].RCharacterImage.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            dialogueLines[index].RCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            //lipsync
            dialogueLines[index].RCharacterImage.GetComponent<AudioSource>().clip = dialogueLines[index].speakerAudio;
            dialogueLines[index].RCharacterImage.GetComponent<AudioSource>().Play();
        }

        nameComponent.text = dialogueLines[index].speakerName;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
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
            dialogueLines[index].LCharacterImage.SetActive(false);
            dialogueLines[index].RCharacterImage.SetActive(false);

            index++;

            dialogueLines[index].LCharacterImage.SetActive(true);
            dialogueLines[index].RCharacterImage.SetActive(true);

            nameComponent.text = dialogueLines[index].speakerName;
            textComponent.text = string.Empty;

            dialogueLines[index].LCharacterImage.GetComponent<Renderer>().material = dialogueLines[index].LCharacterMaterial;
            Vector3 scaleL = dialogueLines[index].LCharacterImage.transform.localScale;
            if (scaleL.x > 0) {
                scaleL.x *= -1;
                dialogueLines[index].LCharacterImage.transform.localScale = scaleL;
                dialogueLines[index].LCharacterImage.transform.position = new Vector3(-dialogueLines[index].LCharacterImage.transform.position.x, dialogueLines[index].LCharacterImage.transform.position.y, dialogueLines[index].LCharacterImage.transform.position.z);
            }
                
            dialogueLines[index].RCharacterImage.GetComponent<Renderer>().material = dialogueLines[index].RCharacterMaterial;
            Vector3 scaleR = dialogueLines[index].RCharacterImage.transform.localScale;
            if (scaleR.x < 0) {
                scaleR.x *= -1;
                dialogueLines[index].RCharacterImage.transform.localScale = scaleR;
                dialogueLines[index].RCharacterImage.transform.position = new Vector3(-dialogueLines[index].RCharacterImage.transform.position.x, dialogueLines[index].RCharacterImage.transform.position.y, dialogueLines[index].RCharacterImage.transform.position.z);
            }

            if (dialogueLines[index].activo == "L") {
                //ocurecer
                dialogueLines[index].RCharacterImage.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
                dialogueLines[index].RCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
                //iluminar
                dialogueLines[index].LCharacterImage.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                dialogueLines[index].LCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                //lipsync
                dialogueLines[index].LCharacterImage.GetComponent<AudioSource>().clip = dialogueLines[index].speakerAudio;
                dialogueLines[index].LCharacterImage.GetComponent<AudioSource>().Play();
            } else {
                //oscurecer
                dialogueLines[index].LCharacterImage.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
                dialogueLines[index].LCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
                //iluminar
                dialogueLines[index].RCharacterImage.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                dialogueLines[index].RCharacterImage.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                //lipsync
                dialogueLines[index].RCharacterImage.GetComponent<AudioSource>().clip = dialogueLines[index].speakerAudio;
                dialogueLines[index].RCharacterImage.GetComponent<AudioSource>().Play();
            }

            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            nameComponent.text = string.Empty;

            gameObject.SetActive(false);
            dialogueLines[index].LCharacterImage.SetActive(false);
            dialogueLines[index].RCharacterImage.SetActive(false);
        }
    } 
}
