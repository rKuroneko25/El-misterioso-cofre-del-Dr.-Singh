using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue1_2 : MonoBehaviour
{
    public TextMeshProUGUI nameComponent;
    public TextMeshProUGUI textComponent;

    public int GuardarEscena;

    void Start()
    {
        if (GuardarEscena > 0)
        {
            switch (PlayerPrefs.GetInt("SaveActual"))
            {
                case 1:
                    PlayerPrefs.SetInt("Escena1", GuardarEscena);
                    break;
                case 2:
                    PlayerPrefs.SetInt("Escena2", GuardarEscena);
                    break;
                case 3:
                    PlayerPrefs.SetInt("Escena3", GuardarEscena);
                    break;
            }
        }
    }

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

    public void escribir(int index)
    {
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
