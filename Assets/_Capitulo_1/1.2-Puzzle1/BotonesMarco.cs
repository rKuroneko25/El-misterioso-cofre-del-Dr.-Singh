using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesMarco : MonoBehaviour
{

    public GameObject Pista;
    public GameObject Info;

    public void pista()
    {
        Pista.SetActive(true);
    }

    public void info()
    {
        Info.SetActive(true);
    }
}
