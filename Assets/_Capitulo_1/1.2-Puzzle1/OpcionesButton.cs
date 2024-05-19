using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesButton : MonoBehaviour
{
    public GameObject opciones;
    public GameObject bloqueo;
    public GameObject gameplay;

    public void OnMouseDown()
    {
        opciones.SetActive(true);
        gameplay.SetActive(false);
        bloqueo.SetActive(true);
    }
}
