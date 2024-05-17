using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Carousel galeria;
    public bool esSiguiente;

    void OnMouseDown()
    {
        if (esSiguiente)
        {
            galeria.ShowNextImage();
        }
        else
        {
            galeria.ShowPreviousImage();
        }
    }
}
