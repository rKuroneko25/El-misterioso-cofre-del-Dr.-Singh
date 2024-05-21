using UnityEngine;
using UnityEngine.EventSystems;

public class Boton : MonoBehaviour, IPointerClickHandler
{
    public Carousel galeria;
    public bool esSiguiente;

    public void OnPointerClick(PointerEventData eventData)
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