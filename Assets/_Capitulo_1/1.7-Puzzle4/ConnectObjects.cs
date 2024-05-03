using UnityEngine;

public class ConnectObjects : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0; // Inicialmente no hay puntos
    }

    // Método para añadir un punto a la línea
    public void AddPoint(Vector3 point)
    {
        int pointCount = lineRenderer.positionCount;
        lineRenderer.positionCount = pointCount + 1;
        lineRenderer.SetPosition(pointCount, point);
    }

    // Método para eliminar todos los puntos de la línea
    public void ClearLine()
    {
        lineRenderer.positionCount = 0;
    }
}