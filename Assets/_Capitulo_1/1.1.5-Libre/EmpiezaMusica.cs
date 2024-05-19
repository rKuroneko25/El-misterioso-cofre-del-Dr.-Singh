using UnityEngine;

public class EmpiezaMusica : MonoBehaviour
{
    private AudioManager musicManager;
    private AudioManager2 sfxManager;

    void Start()
    {
        musicManager = GameObject.Find("AudioManager (Musica)").GetComponent<AudioManager>();
        sfxManager = GameObject.Find("AudioManager (SFX)").GetComponent<AudioManager2>();

        musicManager.Stop(musicManager.GetCurrentPlayingSong());
        musicManager.Play("Puzle");
    }

    void Update()
    {
        sfxManager.Volume(PlayerPrefs.GetFloat("VolumenSFX"));
        musicManager.Volume(PlayerPrefs.GetFloat("VolumenMusica"));
    }
}
