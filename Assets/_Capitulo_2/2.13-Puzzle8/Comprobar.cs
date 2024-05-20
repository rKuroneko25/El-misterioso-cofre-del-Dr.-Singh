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
            ((draggableImage1.transform.position.x >= 502 && draggableImage1.transform.position.y <= 538 && 
            draggableImage1.transform.position.y >= 426 && draggableImage1.transform.position.y <= 550) ||
            (draggableImage1.transform.position.x >= -106 && draggableImage1.transform.position.x <= 648 && 
            draggableImage1.transform.position.y >= 609 && draggableImage1.transform.position.y <= 550)))
        {
            final = true;
        }
        else{
            Debug.Log("X" + draggableImage1.transform.position.x);
            Debug.Log(draggableImage1.transform.position.y);
            Debug.Log(carousel.currentIndex);
        }
    }
}
