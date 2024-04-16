using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BotonesResolver : MonoBehaviour
{
    private static int parrafosOcultos = 4;
    //par de boton y si esta activo o no
    private class  Boton{
        public GameObject boton;
        public bool activo;}
    private static  List<Boton> botones = new List<Boton>();

    private static Dictionary<string, int> parrafos= new Dictionary<string, int>{
        {"Kaufurkunde", 1},
        {"Morgege", 2},
        {"Vorbehalt", 3},
        {"Kaupfreis", 4},
        {"Grezen", 5},
        {"Kundigung", 6},
        {"Kaufer", 7},
        {"Verkaufer", 8}
    };

    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    
    
    void activaBoton(string nombre, GameObject boton, bool Manual_Contrato){
        //cambia la opacidad de la imagen del boton
        if(parrafosOcultos == 0 || botones.Count==2){
            return;
        }
        // buscar si hay un true en el diccionario y ponerlo en false
        if(Manual_Contrato){ //true es que es del manual
            if(botones.Count==1){
                if(botones[0].boton.tag == boton.tag && 
                botones[0].boton!= boton){ // se tiene que desvelar el parrafo
                    botones[1]= new Boton{boton=boton, activo=true};
                    boton.GetComponent<Image>().color = new Color(109,109,109,90);
                    
                    foreach(Boton b in botones){
                        b.boton.SetActive(false);
                    }
                    botones= new List<Boton>();

                    //llamada a reverlar parrafo
                    Debug.Log("Parrafo "+parrafos[nombre]+" Resuelto");
                    parrafosOcultos--;

                    if(parrafosOcultos == 0){
                        Debug.Log("Puzzle Resuelto");
                    }

                }
                else{
                    //hay que desactivar el boton anterior        
                    botones[0].boton.GetComponent<Image>().color = new Color(0,0,0,0);
                    botones= new List<Boton>();
                }
            }
            else{
                boton.GetComponent<Image>().color = new Color(109,109,109,90);
                botones[0]= new Boton{boton=boton, activo=true};
            }
            
            
    }
}

///funcion para boton de mostrar parrafo
public void mostrarParrafo(int parrafo){
   
    if(botones.Count == 2 && parrafosOcultos>0){
        //llamar a la funcion que muestra el parrafo
        
    
    }
    
}

/////////////////////////Botones Manual//////////////////////////////////////////

    public void KaufurkundeM(){
        Debug.Log("Kaufurkunde Manual");
        activaBoton("Kaufurkunde", gameObject, true);
    }

    public void MorgegeM(){
        Debug.Log("Morgege Manual");
        activaBoton("Morgege", gameObject, true);
    }

    public void VorbehaltM(){
        Debug.Log("Vorbehalt Manual");
        activaBoton("Vorbehalt", gameObject, true);
    }

    public void KaupfreisM(){
        Debug.Log("Kaupfreis Manual");
        activaBoton("Kaupfreis", gameObject, true);
    }

    public void GrezenM(){
        Debug.Log("Grezen Manual");
        activaBoton("Grezen", gameObject, true);
    }

    public void KundigungM(){
        Debug.Log("Kundigung Manual");
        activaBoton("Kundigung", gameObject, true);
    }

    public void KauferM(){
        Debug.Log("Kaufer Manual");
        activaBoton("Kaufer", gameObject, true);
    }

    public void VerkauferM(){
        Debug.Log("Verkaufer Manual");
        activaBoton("Verkaufer", gameObject, true);
    }
/////////////////////////Botones Contrato//////////////////////////////////////////

    public void MorgegeC(){
        Debug.Log("Morgege Contrato");
        activaBoton("Morgege", gameObject, false);
    }

    public void VorbehaltC(){
        Debug.Log("Vorbehalt Contrato");
        activaBoton("Vorbehalt", gameObject, false);
    }

    public void KundigungC(){
        Debug.Log("Kundigung Contrato");
        activaBoton("Kundigung", gameObject, false);
    }

    public void KauferC(){
        Debug.Log("Kaufer Contrato");
        activaBoton("Kaufer", gameObject, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
