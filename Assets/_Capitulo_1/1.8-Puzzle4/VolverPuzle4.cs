using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverPuzle4 : MonoBehaviour
{
    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("Volviendo", 1);

        SceneManager.LoadScene("_Capitulo_1/1.8-Puzzle4/Puzzle4");
    }
}
