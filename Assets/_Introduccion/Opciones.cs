using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{
    public GameObject opciones;

    public void OnMouseDown()
    {
        opciones.SetActive(true);
    }
}
