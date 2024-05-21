using UnityEngine;

public class mamawebo3 : MonoBehaviour
{
    private AudioManager musicManager;
    private string musicaActiva;

    void Start()
    {
        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        musicaActiva = musicManager.GetCurrentPlayingSong();
        musicManager.Stop(musicaActiva);
        musicManager.Play("Puzle");

        switch (PlayerPrefs.GetInt("SaveActual"))
        {
            case 1:
                PlayerPrefs.SetInt("Escena1", 15);
                break;
            case 2:
                PlayerPrefs.SetInt("Escena2", 15);
                break;
            case 3:
                PlayerPrefs.SetInt("Escena3", 15);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
