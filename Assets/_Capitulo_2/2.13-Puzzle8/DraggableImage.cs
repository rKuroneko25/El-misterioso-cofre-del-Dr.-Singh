using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableImage : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Vector2 originalPosition;
    private RectTransform rectTransform;
    public RectTransform parentRectTransform; // La imagen padre

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Guarda la posición original cuando se hace clic en la imagen.
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calcula la nueva posición de la imagen.
        Vector2 newPosition = rectTransform.anchoredPosition + eventData.delta / parentRectTransform.localScale.x;

        // Calcula los límites de la imagen padre en relación a su pivote.
        float minX = parentRectTransform.rect.min.x + rectTransform.rect.width / 2;
        float maxX = parentRectTransform.rect.max.x - rectTransform.rect.width / 2;
        float minY = parentRectTransform.rect.min.y + rectTransform.rect.height / 2;
        float maxY = parentRectTransform.rect.max.y - rectTransform.rect.height / 2;

        // Verifica si la nueva posición está dentro de los límites de la imagen padre.
        if (newPosition.x >= minX && newPosition.x <= maxX &&
            newPosition.y >= minY && newPosition.y <= maxY)
        {
            // Si la nueva posición está dentro de los límites, mueve la imagen a la nueva posición.
            rectTransform.anchoredPosition = newPosition;
        }
    }
}