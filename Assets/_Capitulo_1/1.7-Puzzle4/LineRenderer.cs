using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ConnectObjects : MonoBehaviour
{
    public Transform object1;
    public Transform object2;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Establecer el número de puntos en la línea

        // Obtener las posiciones de los objetos y establecerlos como puntos de la línea
        Vector3[] positions = new Vector3[2];
        positions[0] = object1.position;
        positions[1] = object2.position;
        lineRenderer.SetPositions(positions);
    }
}

