using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesCiudades : MonoBehaviour
{   
    private static GameObject BotonSeleccionado= null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SeleccionaBoton(GameObject boton){
        //cambia la opacidad de la imagen del boton
        if(BotonSeleccionado != null){
            Color color1 =BotonSeleccionado.GetComponent<Image>().color ;
            color1.a= 0;
            BotonSeleccionado.GetComponent<Image>().color = color1;
        }
        Color color = boton.GetComponent<Image>().color;
        color.a = 0.5f;
        boton.GetComponent<Image>().color = color;
        BotonSeleccionado= boton;
    }

    public void BotonBristol(){
        SeleccionaBoton(gameObject);
        Debug.Log("Bristol");
    }
    public void BotonLondres(){
        SeleccionaBoton(gameObject);
        Debug.Log("Londres");
    }
    public void BotonMan(){
        SeleccionaBoton(gameObject);
        Debug.Log("Man");
    }
    public void BotonBirmingham(){
        SeleccionaBoton(gameObject);
        Debug.Log("Birmingham");
    }

    public void Resolver(){
        if(BotonSeleccionado.name != "Bristol"){
            // que ponga el audio de no creo que sea esa
           Debug.Log("No creo que sea esa");
        }
        else{
            // que ponga el audio de puzzle resuelto y se pase a la siguiente escena
            Debug.Log("Puzzle resuelto");
        }
    }
}