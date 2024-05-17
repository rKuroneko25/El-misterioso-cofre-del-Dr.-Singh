using UnityEngine;
using TMPro; // Importa el espacio de nombres TMPro

public class CuentaAtras : MonoBehaviour
{
    public float totalTime = 60f; // Tiempo total en segundos
    private float currentTime;    // Tiempo restante

    public TextMeshProUGUI countdownText; // Referencia al texto donde se muestra la cuenta atrás

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        // Resta el tiempo
        currentTime -= Time.deltaTime;

        // Actualiza el texto mostrando el tiempo restante
        countdownText.text = "Tiempo Restante: " + currentTime.ToString("F0"); // "F0" para mostrar como número entero

        // Controla el final de la cuenta atrás
        if (currentTime <= 0)
        {
            // Aquí puedes hacer lo que quieras al finalizar la cuenta atrás
            Debug.Log("Tiempo agotado");
            // Por ejemplo, detener el juego
            Time.timeScale = 0f; // Detiene el tiempo del juego
        }
    }
}