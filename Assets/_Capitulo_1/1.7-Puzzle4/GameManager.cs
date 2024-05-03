using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ConnectObjects connectObjects;
    public Transform object1;
    public Transform object2;

    void Start()
    {
        // Dibuja una línea entre object1 y object2
        connectObjects.AddPoint(object1.position);
        connectObjects.AddPoint(object2.position);
    }

    // Método para limpiar la línea
    public void ClearLine()
    {
        connectObjects.ClearLine();
    }
}