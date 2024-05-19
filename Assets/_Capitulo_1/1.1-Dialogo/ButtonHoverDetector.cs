using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isMouseOverButton = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOverButton = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOverButton = false;
    }
}
