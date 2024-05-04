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
        public string tag;
        public bool Manual_Contrato;}

    private static Boton BotonAnterior= null;
    public Button[] botonesCiudades;
    public GameObject[] parrafosContrato;
    public GameObject ContratoEspanol;
    private static Dictionary<string, string> parrafos= new Dictionary<string, string>{
        {"Morgege", "1"},
        {"Vorbehalt", "2"},  
        {"Kaufer", "3"},          
        {"Kundigung", "4"},
    };

    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    
    
    void activaBoton(string nombre, GameObject boton, bool Manual_Contrato){
        //cambia la opacidad de la imagen del boton
        if(parrafosOcultos == 0 ){
            return;
        }
        // buscar si hay un true en el diccionario y ponerlo en false
        
        if(BotonAnterior != null){
            if(BotonAnterior.tag == nombre && BotonAnterior.boton!= boton 
            && Manual_Contrato != BotonAnterior.Manual_Contrato){ // se tiene que desvelar el parrafo
                
                
                
                

                Color color =BotonAnterior.boton.GetComponent<Image>().color ;
                color.a= 0;
                BotonAnterior.boton.GetComponent<Image>().color = color;
                GameObject[] BotonesDesactivar= GameObject.FindGameObjectsWithTag(nombre);
                foreach(GameObject botonDesactivar in BotonesDesactivar){
                    Button bot= botonDesactivar.GetComponent<Button>();
                    bot.interactable= false;
                }
                
                BotonAnterior= null;

                //llamada a revelar parrafo
                Debug.Log("Revelar Parrafo"+parrafos[nombre]);
                parrafosContrato[Int32.Parse(parrafos[nombre])-1].SetActive(true);

              
                parrafosOcultos--;
                if(parrafosOcultos == 0){
                    Debug.Log("Puzzle Resuelto");
                    ContratoEspanol.gameObject.SetActive(true);
                }

            }
            else{
                //hay que desactivar el boton anterior        
                Color color =BotonAnterior.boton.GetComponent<Image>().color ;
                color.a= 0;
                BotonAnterior.boton.GetComponent<Image>().color = color;
                BotonAnterior= null;
                Debug.Log("Boton Anterior Desactivado");
            }
        }
        else{
            Color color= boton.GetComponent<Image>().color;  //new Color(109,109,109,90);
            color.a= 0.5f;
            boton.GetComponent<Image>().color = color;
            BotonAnterior=new Boton{boton=boton, tag=nombre, Manual_Contrato=Manual_Contrato};
            Debug.Log("Boton "+BotonAnterior.tag+" Activado");
        }
        
            
        
    
    }



/////////////////////////Botones Manual//////////////////////////////////////////

    public void KaufurkundeM(){
        Debug.Log("Kaufurkunde Manual");
        activaBoton("Kaufurkunde", gameObject, true);
        //imprime la lista de botones
        
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
