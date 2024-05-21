using UnityEngine.EventSystems;
using UnityEngine;

public class Pressed : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("El ratón está sobre el objeto" + gameObject.name);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("El ratón ha salido del objeto." + gameObject.name);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
