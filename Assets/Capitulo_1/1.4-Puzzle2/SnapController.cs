using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggablesObjects;
    public float snapRange = 0.5f;

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

        foreach(Transform snapPoint in snapPoints)
        {
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
        }
    }

}