using UnityEngine;
using UnityEngine.UI;

public class ImageClickHandler : MonoBehaviour
{
    public Image[] images; // Referencias a las imágenes
    public Vector2[] correctPoints; // Puntos correctos para cada imagen
    public float tolerance = 10f; // Tolerancia en píxeles para el clic correcto

    void Start()
    {
        if (images.Length != correctPoints.Length)
        {
            Debug.LogError("La cantidad de imágenes y puntos correctos no coincide.");
            return;
        }

        // Agregar listeners de clic a cada imagen
        for (int i = 0; i < images.Length; i++)
        {
            int index = i; // Necesario para el closure en el loop
            images[i].gameObject.AddComponent<Button>().onClick.AddListener(() => OnImageClick(index));
        }
    }

    void OnImageClick(int index)
    {
        Vector2 localMousePosition = GetLocalMousePosition(images[index]);

        if (IsPointCorrect(localMousePosition, correctPoints[index]))
        {
            Debug.Log("¡Punto correcto en la imagen " + index + "!");
        }
        else
        {
            Debug.Log("Punto incorrecto en la imagen " + index + ".");
        }
    }

    Vector2 GetLocalMousePosition(Image image)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(image.rectTransform, Input.mousePosition, null, out Vector2 localPoint);
        return localPoint;
    }

    bool IsPointCorrect(Vector2 clickedPoint, Vector2 correctPoint)
    {
        return Vector2.Distance(clickedPoint, correctPoint) <= tolerance;
    }
}
