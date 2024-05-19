using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    private Slider slider;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        switch (gameObject.name)
        {
            case "Slider (Musica)":
                slider.value = PlayerPrefs.GetFloat("VolumenMusica");
                break;
            case "Slider (SFX)":
                slider.value = PlayerPrefs.GetFloat("VolumenSFX");
                break;
            case "Slider (Voces)":
                slider.value = PlayerPrefs.GetFloat("VolumenVoces");
                break;
        }
        audioManager.Volume((float)(slider.value / 100));
    }

    public void ChangeSlider1()
    {
        audioManager.Volume((float)(slider.value / 100));
        PlayerPrefs.SetFloat("VolumenMusica", slider.value);
    }

    public void ChangeSlider2()
    {
        audioManager.Volume((float)(slider.value / 100));
        PlayerPrefs.SetFloat("VolumenSFX", slider.value);
    }

    public void ChangeSlider3()
    {
        PlayerPrefs.SetFloat("VolumenVoces", (float)(slider.value / 100));
    }

}
