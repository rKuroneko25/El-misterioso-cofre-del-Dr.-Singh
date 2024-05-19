using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    private Slider slider;
    public AudioManager audioManager;
    public AudioManager2 audioManager2;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        switch (gameObject.name)
        {
            case "Slider (Musica)":
                slider.value = PlayerPrefs.GetFloat("VolumenMusica")*100;
                break;
            case "Slider (SFX)":
                slider.value = PlayerPrefs.GetFloat("VolumenSFX")*100;
                break;
            case "Slider (Voces)":
                slider.value = PlayerPrefs.GetFloat("VolumenVoces")*100;
                break;
        }
        audioManager.Volume((float)(slider.value / 100));
    }

    public void ChangeSlider1()
    {
        audioManager.Volume((float)(slider.value / 100));
        PlayerPrefs.SetFloat("VolumenMusica", (float)(slider.value/100));
    }

    public void ChangeSlider2()
    {
        audioManager2.Volume((float)(slider.value / 100));
        PlayerPrefs.SetFloat("VolumenSFX", (float)(slider.value/100));
    }

    public void ChangeSlider3()
    {
        audioManager.Volume((float)(slider.value / 100));
        PlayerPrefs.SetFloat("VolumenVoces", (float)(slider.value/100));
    }

}
