using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggablesObjects;
    public float snapRange = 0.5f;

    private List<Transform> occupiedSnapPoints = new List<Transform>(); // Lista para llevar un registro de los puntos de anclaje ocupados

    void Start()
    {
        foreach (Draggable draggable in draggablesObjects)
        {
            draggable.OnDragEnd = OnDragEnd;
        }
    }

    private void OnDragEnd(Draggable draggableObject)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;
        UpdateOccupiedSnapPoints();

        foreach(Transform snapPoint in snapPoints)
        {
            // Si el punto de anclaje ya está ocupado, pasamos al siguiente punto de anclaje
            if (occupiedSnapPoints.Contains(snapPoint))
            {
                continue;
            }

            float distance = Vector3.Distance(draggableObject.transform.position, snapPoint.position);

            if (closestDistance == -1 || distance < closestDistance)
            {
                closestDistance = distance;
                closestSnapPoint = snapPoint;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggableObject.transform.position = closestSnapPoint.position;
            occupiedSnapPoints.Add(closestSnapPoint); // Añadimos el punto de anclaje a la lista de puntos de anclaje ocupados
        }
    }

    private void UpdateOccupiedSnapPoints()
    {
        // Crea una nueva lista para almacenar los puntos de anclaje que están ocupados
        List<Transform> currentlyOccupiedSnapPoints = new List<Transform>();

        // Comprueba cada punto de anclaje en occupiedSnapPoints
        foreach (Transform snapPoint in occupiedSnapPoints)
        {
            // Comprueba cada objeto arrastrable para ver si está en este punto de anclaje
            foreach (Draggable draggable in draggablesObjects)
            {
                if (Vector3.Distance(draggable.transform.position, snapPoint.position) <= snapRange)
                {
                    // Si se encuentra un objeto arrastrable en este punto de anclaje, añádelo a la lista de puntos de anclaje ocupados
                    currentlyOccupiedSnapPoints.Add(snapPoint);
                    break;
                }
            }
        }

        // Actualiza occupiedSnapPoints para que solo contenga los puntos de anclaje que están actualmente ocupados
        occupiedSnapPoints = currentlyOccupiedSnapPoints;
    }
    }