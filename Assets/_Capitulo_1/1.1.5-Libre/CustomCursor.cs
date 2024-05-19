using UnityEngine;
using UnityEngine.EventSystems;

public class CustomCursorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Texture2D customCursor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (customCursor != null)
        {
            CursorManager.Instance.SetCustomCursor(customCursor);
        }
        else
        {
            CursorManager.Instance.SetHoverCursor();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.Instance.SetNormalCursor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CursorManager.Instance.SetNormalCursor();
    }
}
