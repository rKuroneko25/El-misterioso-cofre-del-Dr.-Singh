using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeConfirmation : MonoBehaviour
{
    public GameObject panelConfirmacion;

    private AudioManager musicManager;
    string currentMusic;

    void Start()
    {
        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        currentMusic = musicManager.GetCurrentPlayingSong();
    }

    public void OnYesButton()
    {
        musicManager.Stop(currentMusic);
        musicManager.Play("MenuMusic");
        SceneManager.LoadScene("_Introduccion/Main Menu");
    }

    public void OnNoButton()
    {
        panelConfirmacion.SetActive(false);
    }
}
