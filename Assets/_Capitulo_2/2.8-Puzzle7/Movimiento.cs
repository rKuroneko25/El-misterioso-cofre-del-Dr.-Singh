using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{   static public int posicion = 1;
    public Fallar failScript;

    Dictionary<string,bool>[] OpcionesBotones=
    new Dictionary<string,bool>[18];

    public GameObject[][] waypoints=new GameObject[18][];

    private Dictionary<int,int> posicionsFadeOUT= new Dictionary<int,int>(){
        { 1,1}, {5,2},{7,1}, {8,2}, {11,1}, {12,1},{14,2},{15,1},{17,2 }
    };

    private Dictionary<int,int> posicionsFadeIN= new Dictionary<int,int>(){
        { 1,2}, {5,2},{7,1}, {8,2}, {11,1}, {12,2},{14,2},{15,2},{18,1}
    };
    
    
    private GameObject sprite;
    private float speed = 3.0f;
    private float tiempoAnimacion=0.5f;

    // Start is called before the first frame update
    void Start()
    {   
        sprite = GameObject.FindGameObjectWithTag("Player");
        Transform waypointsParent = GameObject.Find("waypoints").transform;
        waypoints[0] = new GameObject[] { waypointsParent.Find("Waypoint1_1").gameObject, waypointsParent.Find("Waypoint1_2").gameObject, waypointsParent.Find("Waypoint1_3").gameObject };
        waypoints[1] = new GameObject[] { waypointsParent.Find("Waypoint2_1").gameObject };
        waypoints[2] = new GameObject[] { waypointsParent.Find("Waypoint3_1").gameObject };
        waypoints[3] = new GameObject[] { waypointsParent.Find("Waypoint4_1").gameObject };
        waypoints[4] = new GameObject[] { waypointsParent.Find("Waypoint5_1").gameObject, waypointsParent.Find("Waypoint5_2").gameObject };
        waypoints[5] = new GameObject[] { waypointsParent.Find("Waypoint6_1").gameObject };
        waypoints[6] = new GameObject[] { waypointsParent.Find("Waypoint7_1").gameObject, waypointsParent.Find("Waypoint7_2").gameObject };
        waypoints[7] = new GameObject[] { waypointsParent.Find("Waypoint8_1").gameObject, waypointsParent.Find("Waypoint8_2").gameObject };
        waypoints[8] = new GameObject[] { waypointsParent.Find("Waypoint9_1").gameObject };
        waypoints[9] = new GameObject[] { waypointsParent.Find("Waypoint10_1").gameObject };
        waypoints[10] = new GameObject[] { waypointsParent.Find("Waypoint11_1").gameObject, waypointsParent.Find("Waypoint11_2").gameObject};
        waypoints[11] = new GameObject[] { waypointsParent.Find("Waypoint12_1").gameObject, waypointsParent.Find("Waypoint12_2").gameObject, waypointsParent.Find("Waypoint12_3").gameObject};
        waypoints[12] = new GameObject[] { waypointsParent.Find("Waypoint13_1").gameObject };
        waypoints[13] = new GameObject[] { waypointsParent.Find("Waypoint14_1").gameObject, waypointsParent.Find("Waypoint14_2").gameObject , waypointsParent.Find("Waypoint14_3").gameObject};
        waypoints[14] = new GameObject[] { waypointsParent.Find("Waypoint15_1").gameObject, waypointsParent.Find("Waypoint15_2").gameObject};
        waypoints[15] = new GameObject[] { waypointsParent.Find("Waypoint16_1").gameObject };
        waypoints[16] = new GameObject[] { waypointsParent.Find("Waypoint17_1").gameObject, waypointsParent.Find("Waypoint17_2").gameObject, waypointsParent.Find("Waypoint17_3").gameObject };
        waypoints[17] = new GameObject[] { waypointsParent.Find("Waypoint18_1").gameObject };
        
        

        OpcionesBotones[0] = new Dictionary<string,bool>{
            {"I",false},
            {"D",false},
            {"AR",true}
        };
        OpcionesBotones[1] = new Dictionary<string,bool>{
            {"I",false},
            {"D",true},
            {"AR",false}
        };
        OpcionesBotones[2] = new Dictionary<string,bool>{
            {"D",true},
        };
        OpcionesBotones[3] = new Dictionary<string,bool>{
            {"I",true},
        };
        OpcionesBotones[4] = new Dictionary<string,bool>{
            {"I",false},
            {"D",false},
            {"ARI",true}
        };
        OpcionesBotones[5] = new Dictionary<string,bool>{
            {"I",true},
            {"AR",false},
            {"D",false}
        };
        OpcionesBotones[6] = new Dictionary<string,bool>{
            {"I",false},
            {"D",false},
            {"ABI",true}
        };
        OpcionesBotones[7] = new Dictionary<string,bool>{
            {"ABD",true},
            {"D",false}
        };
        OpcionesBotones[8] = new Dictionary<string,bool>{
            {"E",false},
            {"AB",true}
        };
        OpcionesBotones[9] = new Dictionary<string,bool>{
            {"D",false},
            {"ARI",true},
            {"I",true}
        };
        OpcionesBotones[10] = new Dictionary<string,bool>{
            {"AR",true},
        };
        OpcionesBotones[11] = new Dictionary<string,bool>{
            {"AR",true},
            {"D",false},
            {"AB",false}
        };
        OpcionesBotones[12] = new Dictionary<string,bool>{
            {"I",false},
            {"AB",false},
            {"D",true}
        };
        OpcionesBotones[13] = new Dictionary<string,bool>{
            {"E",false},
            {"AR",true},
        };
        OpcionesBotones[14] = new Dictionary<string,bool>{
            {"I",false},
            {"AR",true},
        };
        OpcionesBotones[15] = new Dictionary<string,bool>{
            {"E",false},
            {"AB",true},
        };
        OpcionesBotones[16] = new Dictionary<string,bool>{
            {"I",false},
            {"D",true}
        };

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cambiapos(int pos){
        if (pos != 1)
        {
            StartCoroutine(MoveThroughWaypoints(posicion));
        }
    }

    IEnumerator fadeAnimation(string trigger){
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger(trigger);
        yield return new WaitForSeconds(tiempoAnimacion);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().ResetTrigger(trigger);
    }

    IEnumerator MoveThroughWaypoints(int row)
    {
        if (row >= 0 && row < waypoints.Length)
        {   Debug.Log("Row: "+row);
            Debug.Log("Posicion: "+posicion);
            //si esta en el diccionario de posiciones que se desvanecen, activa el trigger de out
            

            //pone los botones anteriores en no interactuable
            foreach (KeyValuePair<string, bool> kvp in OpcionesBotones[posicion-1])
            {   Button boton=GameObject.FindGameObjectWithTag(kvp.Key).GetComponent<Button>();
                Color color= GameObject.FindGameObjectWithTag(kvp.Key).GetComponent<Image>().color;
                
                boton.interactable = false;  
                GameObject.FindGameObjectWithTag(kvp.Key).GetComponent<Image>().color = new Color(color.r,color.g,color.b,0f);
                
            }
            int Movimiento=1;
            foreach (GameObject waypoint in waypoints[row-1])
            {   
                if (waypoint != null)
                {
                    yield return StartCoroutine(MoveToPosition(sprite, waypoint.transform.position, posicion,Movimiento));
                    Movimiento++;
                }
                else
                {
                    Debug.LogError("Uno de los waypoints es null.");
                }
            }
            //pone las nuevas opciones de botones
            if(row!=17){
                foreach (KeyValuePair<string, bool> kvp in OpcionesBotones[row])
                {   
                    
                    Button boton=GameObject.FindGameObjectWithTag(kvp.Key).GetComponent<Button>();
                    Color color= GameObject.FindGameObjectWithTag(kvp.Key).GetComponent<Image>().color;
                    
                        boton.interactable = true;
                        GameObject.FindGameObjectWithTag(kvp.Key).GetComponent<Image>().color = new Color(color.r,color.g,color.b,1f);
                }
            }
            
            if(row+1==18){
                Debug.Log("Ganaste");
                foreach(GameObject waypoint in waypoints[17]){
                    yield return StartCoroutine(MoveToPosition(sprite, waypoint.transform.position, row,1));
                }
            }
            posicion = row+1;
            Debug.Log("Posicion: "+posicion);
        }
        else
        {
            Debug.LogError("row está fuera de los límites de la matriz waypoints.");
        }
    }

    IEnumerator MoveToPosition(GameObject objectToMove, Vector3 targetPosition,int pos, int Movimiento)
    {   if(posicionsFadeOUT.ContainsKey(posicion)){
            if( posicionsFadeOUT[pos]==Movimiento)
            {
                StartCoroutine(fadeAnimation("out"));
            }
        }
        
        while (Vector3.Distance(objectToMove.transform.position, targetPosition) > 0.01f)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null; // Espera un frame antes de continuar el bucle
        }

        if(posicionsFadeIN.ContainsKey(posicion)){
            if(posicionsFadeIN[pos]==Movimiento)
            {
                StartCoroutine(fadeAnimation("in"));
            }
        }
        

        // Asegúrate de que la posición final sea exacta
        objectToMove.transform.position = targetPosition;
    }


    void funcionIntermedia(string tag){
        if(OpcionesBotones[posicion-1][tag]){
            cambiapos(posicion+1);
        }
        else{
            failScript.fail();
            //animacion de error, texto de error y retry?
        }
    }

    public void MoverIzquierda(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Izquierda");
    }
    public void MoverDerecha(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Derecha");
    }
    public void MoverArriba(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Arriba");
    }
    public void MoverAbajo(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Abajo");
    }
    public void MoverArribaIzquierda(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Arriba Izquierda");
    }
    public void Esperar(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Esperar");
    }
    public void MoverAbajoIzquierda(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Abajo Izquierda");
    }
    public void MoverAbajoDerecha(){
        funcionIntermedia(gameObject.tag);
        Debug.Log("Abajo Derecha");
    }
    

}
