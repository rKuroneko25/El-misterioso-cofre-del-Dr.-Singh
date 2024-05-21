using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public GameObject panelConfirmacion;

    public void OpenPanel()
    {
        panelConfirmacion.SetActive(true);
    }
}
