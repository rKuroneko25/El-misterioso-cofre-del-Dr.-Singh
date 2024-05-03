using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Partida : MonoBehaviour
{

    public GameObject Save1;
    public GameObject Save2;
    public GameObject Save3;
    public GameObject Vacio1;
    public GameObject Vacio2;
    public GameObject Vacio3;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Save1") == 1)
        {
            Save1.SetActive(true);
            Vacio1.SetActive(false);
            Save1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Capítulo: " + (PlayerPrefs.GetInt("Escena1") < 10 ? 1 : 2) + "\nSecretos: " + PlayerPrefs.GetInt("Secrets1");
        }
        else
        {
            Save1.SetActive(false);
            Vacio1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Save2") == 1)
        {
            Save2.SetActive(true);
            Vacio2.SetActive(false);
            Save2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Capítulo: " + (PlayerPrefs.GetInt("Escena2") < 10 ? 1 : 2) + "\nSecretos: " + PlayerPrefs.GetInt("Secrets2");
        }
        else
        {
            Save2.SetActive(false);
            Vacio2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Save3") == 1)
        {
            Save3.SetActive(true);
            Vacio3.SetActive(false);
            Save3.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Capítulo: " + (PlayerPrefs.GetInt("Escena3") < 10 ? 1 : 2) + "\nSecretos: " + PlayerPrefs.GetInt("Secrets3");
        }
        else
        {
            Save3.SetActive(false);
            Vacio3.SetActive(true);
        }
    }
}
