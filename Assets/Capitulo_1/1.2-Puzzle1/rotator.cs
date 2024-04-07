using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{   
    [SerializeField] float rotationSpeed = 50f;
    bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (!IsPointerOverText())
        {
            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.down, x);
            
            float currentXRotation = transform.eulerAngles.x;
            float newXRotation = currentXRotation + y;
            if (newXRotation < 15 || newXRotation > 345) // Si la rotación excede los 15 grados hacia arriba o hacia abajo
            {
                transform.Rotate(Vector3.right, y);
            }

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        }
    }

    private bool IsPointerOverText()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        TextMeshProUGUI[] textMeshPros = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(textMeshPro.rectTransform, Input.mousePosition, eventDataCurrentPosition.enterEventCamera))
            {
                return true;
            }
        }
        return false;
    }
}
