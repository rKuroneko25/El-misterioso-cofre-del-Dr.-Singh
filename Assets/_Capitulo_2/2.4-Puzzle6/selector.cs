using UnityEngine;

public class Selector : MonoBehaviour
{
    public bool esCorrecto; // Determina si este objeto es el correcto.
    public static bool seleccionCorrecta; // Se pone a true si se selecciona el objeto correcto.

    void OnMouseDown()
    {
        if (esCorrecto)
        {
            seleccionCorrecta = true;
            Debug.Log("¡Selección correcta!");
        }
        else
        {
            seleccionCorrecta = false;
            Debug.Log("Selección incorrecta.");
        }
    }
}