using UnityEngine;

public class SalirButton : MonoBehaviour
{
    public GameObject Menu;
    public GameObject bloqueo;
    public GameObject gameplay;

    public void OnMouseDown()
    {
        Menu.SetActive(false);
        gameplay.SetActive(true);
        bloqueo.SetActive(false);
    }
}
