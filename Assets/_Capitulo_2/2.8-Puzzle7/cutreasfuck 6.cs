using UnityEngine;
using UnityEngine.SceneManagement;


public class cutreasfuck6 : MonoBehaviour
{

    private AudioManager musicManager;
    string currentMusic;

    void Start()
    {
        Invoke("Esperar4Segundos", 20);
        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        currentMusic = musicManager.GetCurrentPlayingSong();
        musicManager.Stop(currentMusic);
    }

    void Esperar4Segundos()
    {
        SceneManager.LoadScene("_Capitulo_2/2.8-Puzzle7/Puzzle7");
    }
}
