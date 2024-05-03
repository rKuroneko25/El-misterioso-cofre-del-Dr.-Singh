using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galeria : MonoBehaviour
{
    public Texture2D[] fotos; // Array de fotos
    private int fotoActual = 0; // Índice de la foto actual
    private Renderer rend; // Renderer del objeto

    void Start()
    {
        // Obtiene el Renderer del objeto
        rend = GetComponent<Renderer>();

        // Establece la primera foto
        if (fotos.Length > 0)
        {
            rend.material.mainTexture = fotos[0];
        }
    }

    void OnMouseDown()
    {
        // Cambia a la siguiente foto cuando se hace clic en el objeto
        fotoActual = (fotoActual + 1) % fotos.Length;
        rend.material.mainTexture = fotos[fotoActual];
    }
}