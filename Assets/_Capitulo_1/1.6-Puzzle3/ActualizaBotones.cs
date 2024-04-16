using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ActualizaBotones : MonoBehaviour
{   public Button[] botones_1Pagina;
    public Button[] botones_2Pagina;
    public Book book;
    // Start is called before the first frame update
    void Start()
    {   //suscribir una funcion al UnityEvent OnFlip
        book.OnFlip.AddListener(ActualizarBotones);
        //pon todos los botones en falso
        foreach(Button boton in botones_1Pagina){
            boton.interactable = false;
        }
        foreach(Button boton in botones_2Pagina){
            boton.interactable = false;
        }
    }

    
    

    public void ActualizarBotones(){
        if(book.currentPage == 2){
            foreach(Button boton in botones_1Pagina){
                boton.interactable = true;
            }
            foreach(Button boton in botones_2Pagina){
                boton.interactable = false;
            }
        }
        if(book.currentPage == 4){
            foreach(Button boton in botones_1Pagina){
                boton.interactable = false;
            }
            foreach(Button boton in botones_2Pagina){
                boton.interactable = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
