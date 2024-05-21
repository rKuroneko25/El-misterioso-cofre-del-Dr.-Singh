using UnityEngine;
using TMPro;

public class CuentaAtras : MonoBehaviour
{
    public float totalTime = 60f;
    private float currentTime;

    public Fallar failScript;

    public TextMeshProUGUI countdownText;
    bool coso = true;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        // Asegúrate de que currentTime no caiga por debajo de cero
        if (currentTime < 0)
        {
            currentTime = 0;
        }

        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        countdownText.text = formattedTime;

        if (currentTime <= 0 && coso)
        {
            coso = false;
            Debug.Log("Tiempo agotado");

            failScript.fail();
        }
    }
}