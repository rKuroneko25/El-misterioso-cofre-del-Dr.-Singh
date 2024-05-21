using UnityEngine;

public class SalirMenu : MonoBehaviour
{
    public GameObject Menu;

    public void OnMouseDown()
    {
        Menu.SetActive(false);
    }
}
