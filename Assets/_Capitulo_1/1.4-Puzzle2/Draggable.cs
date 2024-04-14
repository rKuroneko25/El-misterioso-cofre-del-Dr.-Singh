using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate OnDragEnd;

    private bool isDragging = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 objectDragStartPosition;

    private void OnMouseDown()
    {
        isDragging = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
        objectDragStartPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            transform.position = objectDragStartPosition + (currentMousePosition - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        OnDragEnd?.Invoke(this);
    }
}
