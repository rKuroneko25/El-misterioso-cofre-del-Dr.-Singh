using System.Collections;
using TMPro;
using UnityEngine;

public class TemporalText : MonoBehaviour
{
    public TMP_Text textMesh; // Referencia al componente TextMeshPro.

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        textMesh.enabled = true; // Muestra el texto.

        yield return new WaitForSeconds(3); // Espera 6 segundos.

        textMesh.enabled = false; // Oculta el texto.
    }
}