using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LUZ : MonoBehaviour
{
    int[] timings = new int[] { 2, 2, 3, 3, 2, 1, 2 };
    float[] timings2 = new float[] { 0.2f, 0.5f, 0.3f, 0.1f, 0.3f, 0.1f, 0.2f, 0.5f };
    int currentIndex = 0;
    int currentIndex2 = 0;
    public GameObject luz;

    public AudioManager audioManager1;
    public AudioManager audioManager2;
    public AudioManager audioManager3;

    void Start()
    {
        StartCoroutine(ActivarLuz());

        audioManager1.Play("MenuMusic");

        audioManager1.Volume((float)(PlayerPrefs.GetFloat("VolumenMusica")/100));
        audioManager2.Volume((float)(PlayerPrefs.GetFloat("VolumenSFX")/100));
        audioManager3.Volume((float)(PlayerPrefs.GetFloat("VolumenVoces")/100));

    }

    IEnumerator ActivarLuz()
    {
        while (true)
        {
            luz.SetActive(true);
            Debug.Log("Encendido");
            yield return new WaitForSeconds(timings[currentIndex]);
            Debug.Log("Apagado");
            luz.SetActive(false);
            currentIndex = (currentIndex + 1) % timings.Length;
            yield return new WaitForSeconds(timings2[currentIndex2]);
            currentIndex2 = (currentIndex2 + 1) % timings2.Length;
        }
    }


}
