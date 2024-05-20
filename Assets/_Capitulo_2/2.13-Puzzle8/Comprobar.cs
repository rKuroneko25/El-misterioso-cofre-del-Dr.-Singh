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
            ((draggableImage1.transform.position.x >= 502 && draggableImage1.transform.position.x <= 539 && 
            draggableImage1.transform.position.y >= 422 && draggableImage1.transform.position.y <= 554) ||
            (draggableImage1.transform.position.x >= 608 && draggableImage1.transform.position.x <= 647 && 
            draggableImage1.transform.position.y >= 422 && draggableImage1.transform.position.y <= 554)))
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
