using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Comprobar : MonoBehaviour
{
    public Carousel carousel; // Referencia al script Carousel

    public DraggableImage draggableImage1; // Referencia al script DraggableImage de la imagen 1

    public bool final = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void comprobar()
    {
        if (carousel.currentIndex == 3 && 
            ((draggableImage1.originalPosition.x >= 4 && draggableImage1.originalPosition.y <= 53 && 
            draggableImage1.originalPosition.y >= -63 && draggableImage1.originalPosition.y <= 80) ||
            (draggableImage1.originalPosition.x >= -106 && draggableImage1.originalPosition.x <= -55 && 
            draggableImage1.originalPosition.y >= -63 && draggableImage1.originalPosition.y <= 80)))
        {
            final = true;
        }
    }
}
