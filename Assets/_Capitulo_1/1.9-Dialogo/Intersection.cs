using UnityEngine;

public class Intersection : MonoBehaviour
{

    private AudioManager2 sfxManager;
    private AudioManager musicManager;

    string currentMusic;

    public GameObject Oscuro;
    public GameObject OscuroEnd;

    void Start()
    {
        if (Oscuro != null)
        {
            Oscuro.SetActive(true);
            Oscuro.GetComponent<Animator>().SetTrigger("In");
            Invoke("apagarOscuro", 1.5f);
        }

        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        currentMusic = musicManager.GetCurrentPlayingSong();
        musicManager.Stop(currentMusic);

        sfxManager = GameObject.Find("AudioManager (SFX)").GetComponent<AudioManager2>();
        sfxManager.Play("Intermission");
    }

    void apagarOscuro()
    {
        Oscuro.SetActive(false);
    }

    public void Continue()
    {
        Oscuro.SetActive(true);
        Oscuro.GetComponent<Animator>().SetTrigger("Out");
        Invoke("Esperar4Segundos", 1.5f);
    }

    public void title()
    {
        Oscuro.SetActive(true);
        Oscuro.GetComponent<Animator>().SetTrigger("Out");
        Debug.Log("Cargando menú principal...");
        Invoke("Esperar5Segundos", 1.5f);
    }

    void Esperar4Segundos()
    {
        OscuroEnd.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Capitulo_2/2.2-Puzzle5/Info");
    }

    void Esperar5Segundos()
    {
        OscuroEnd.SetActive(true);
        musicManager.Play("MenuMusic");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }


}
