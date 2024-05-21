using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutreasfuck2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Esperar4Segundos", 5);
    }

    void Esperar4Segundos()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
