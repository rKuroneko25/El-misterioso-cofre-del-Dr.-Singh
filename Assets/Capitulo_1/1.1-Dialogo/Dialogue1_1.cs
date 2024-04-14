using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue1_1 : MonoBehaviour
{
    public TextMeshProUGUI nameComponent;
    public TextMeshProUGUI textComponent;
    

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public Texture LCharTexture;
        public Texture RCharTexture;
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
            index++;
            nameComponent.text = dialogueLines[index].speakerName;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            nameComponent.text = string.Empty;
            gameObject.SetActive(false);
        }
    } 
}
