using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            // Obtenemos el rayo desde la cámara al punto donde hicimos clic
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            // Si el rayo golpea al GameObject
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {   Debug.Log("Tuberia clickeada");
                // Activamos el trigger de la animación
                position=(position+1) % 4;
                // lanza la funcion triggerAnimation
                StartCoroutine(triggerAnimation());
                if(position == posicionCorrecta){
                    tuberiasCorrectas++;
                    if(tuberiasCorrectas == 5){
                        Debug.Log("Puzzle resuelto");
                    }
                }
            }
        }
    }


    IEnumerator triggerAnimation(){
        animator.SetTrigger("rot"+position.ToString());
        yield return new WaitForSeconds(1.0f);
        animator.ResetTrigger("rot"+position.ToString());
    }
}
