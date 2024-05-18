using UnityEngine;
using UnityEngine.UI; // Necesario para Image

public class Carousel : MonoBehaviour
{
    public Sprite[] images; // Array para almacenar las imágenes del carrusel.
    public int currentIndex = 0; // Índice de la imagen actualmente visible.
    private Image imagen; // Componente Image del objeto

    void Start()
    {
        // Obtiene el componente Image del objeto
        imagen = GetComponent<Image>();

        // Asegurarse de que la imagen esté por debajo de la capa superior
        imagen.canvas.sortingOrder = -100; // Disminuye este número si necesitas que la imagen esté aún más abajo

        UpdateCarousel();
    }

    public void ShowNextImage()
    {
        currentIndex++;
        if (currentIndex >= images.Length)
        {
            currentIndex = 0; // Volver al principio.
        }
        UpdateCarousel();
    }

    public void ShowPreviousImage()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = images.Length - 1; // Ir al final.
        }
        UpdateCarousel();
    }

    void UpdateCarousel()
    {
        // Muestra la imagen actual en el componente Image
        imagen.sprite = images[currentIndex];
    }
}