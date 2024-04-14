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
        if (Input.GetMouseButtonDown(1))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 90f);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        OnDragEnd?.Invoke(this);
    }
}
