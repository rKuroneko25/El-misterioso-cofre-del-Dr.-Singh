using UnityEngine;

public class SceneChange : MonoBehaviour
{

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    void Start()
    {
        if (PlayerPrefs.GetInt("Volviendo") != 1)
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("In");
            Invoke("apagarOscuro", 1.5f);
        }
        else
        {
            PlayerPrefs.SetInt("Volviendo", 0);
        }
    }

    void apagarOscuro()
    {
        Oscuro.SetActive(false);
    }

    public void CambiarEscena()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ResolverPuzzle4");
    }
}
