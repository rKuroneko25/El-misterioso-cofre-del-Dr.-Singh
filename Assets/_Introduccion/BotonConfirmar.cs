using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BotonConfirmar : MonoBehaviour
{
    public GameObject SioNo;
    // Start is called before the first frame update
    public void Si()
    {
        switch (PlayerPrefs.GetInt("BorrarPartida"))
        {
            case 1:
                PlayerPrefs.SetInt("Save1", 0);
                PlayerPrefs.SetInt("Escena1", 0);
                PlayerPrefs.SetInt("Secrets1", 0);
                break;
            case 2:
                PlayerPrefs.SetInt("Save2", 0);
                PlayerPrefs.SetInt("Escena2", 0);
                PlayerPrefs.SetInt("Secrets2", 0);
                break;
            case 3:
                PlayerPrefs.SetInt("Save3", 0);
                PlayerPrefs.SetInt("Escena3", 0);
                PlayerPrefs.SetInt("Secrets3", 0);
                break;
        }
        SioNo.SetActive(false);
    }

    public void No()
    {
        SioNo.SetActive(false);
    }

}
