using UnityEngine;
using UnityEngine.UI; // Necesario para Image

public class Galeria : MonoBehaviour
{
    public Sprite[] fotos; // Array de fotos
    private int fotoActual = 0; // Índice de la foto actual
    private Image imagen; // Componente Image del objeto

    void Start()
    {
        // Obtiene el componente Image del objeto
        imagen = GetComponent<Image>();

        // Establece la primera foto
        if (fotos.Length > 0)
        {
            imagen.sprite = fotos[0];
        }
    }

    public void SiguienteFoto()
    {
        // Cambia a la siguiente foto
        fotoActual = (fotoActual + 1) % fotos.Length;
        imagen.sprite = fotos[fotoActual];
    }

    public void AnteriorFoto()
    {
        // Cambia a la foto anterior
        fotoActual = (fotoActual - 1 + fotos.Length) % fotos.Length;
        imagen.sprite = fotos[fotoActual];
    }
}
