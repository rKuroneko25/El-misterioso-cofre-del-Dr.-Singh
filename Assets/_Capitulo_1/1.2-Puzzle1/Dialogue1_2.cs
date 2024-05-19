using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue1_2 : MonoBehaviour
{
    public TextMeshProUGUI nameComponent;
    public TextMeshProUGUI textComponent;

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public Texture speakerTexture;
        [TextArea(3, 20)]
        public string dialogueText;
        public float textSpeed;
    }

    public DialogueLine[] dialogueLines;

    public void escribir(int index){
        StartCoroutine(TypeLine(index));
    }

    IEnumerator TypeLine(int index)
    {
        textComponent.text = "";
        nameComponent.text = dialogueLines[index].speakerName;
        foreach (char c in dialogueLines[index].dialogueText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(dialogueLines[index].textSpeed);
        }
    }

}
