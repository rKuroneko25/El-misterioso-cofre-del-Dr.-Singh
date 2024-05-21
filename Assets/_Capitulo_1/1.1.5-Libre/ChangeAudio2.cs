using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio2 : MonoBehaviour
{
    private Slider slider;

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
    }

    public void ChangeSlider1()
    {
        PlayerPrefs.SetFloat("VolumenMusica", (float)(slider.value/100));
    }

    public void ChangeSlider2()
    {
        PlayerPrefs.SetFloat("VolumenSFX", (float)(slider.value/100));
    }

    public void ChangeSlider3()
    {
        PlayerPrefs.SetFloat("VolumenVoces", (float)(slider.value/100));
    }

}
