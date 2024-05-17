using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Giratubería : MonoBehaviour
{       
    public int position;
    public int posicionCorrecta;
    private Animator animator;
    
    static int tuberiasCorrectas = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            if(tuberiasCorrectas < 5 && gameObject.tag == "Tuberia"){
                // Obtenemos el rayo desde la cámara al punto donde hicimos clic
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 5.0f);
                // Si el rayo golpea al GameObject
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == null)
                {   Debug.Log("rayo colisiona con"+hit.collider.gameObject.name);
                    
                }
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {   Debug.Log("Tuberia clickeada");
                    // Activamos el trigger de la animación
                    position=(position+1) % 4;
                    // lanza la funcion triggerAnimation
                    StartCoroutine(triggerAnimationTub());
                    if(position == posicionCorrecta){
                        tuberiasCorrectas++;
                        GetComponent<BoxCollider>().enabled = false;
                        if(tuberiasCorrectas == 5){
                            Debug.Log("Tuberias colocadas correctamente");
                        }
                    }
                }
            }
            else{
                if(tuberiasCorrectas == 5 && gameObject.tag == "Manivela"){
                    StartCoroutine(triggerAnimationManivela());
                    GetComponent<BoxCollider>().enabled = false;
                    Debug.Log("Manivela girada, Puzzle completado");
                }
            }
            
        }
        
    }

    IEnumerator triggerAnimationManivela(){
        animator.SetTrigger("giraManivela");
        yield return new WaitForSeconds(1.5f);
        animator.ResetTrigger("giraManivela");
    }

    IEnumerator triggerAnimationTub(){
        animator.SetTrigger("rot"+position.ToString());
        yield return new WaitForSeconds(1.0f);
        animator.ResetTrigger("rot"+position.ToString());
    }
}
