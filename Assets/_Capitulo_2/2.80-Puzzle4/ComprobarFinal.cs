using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarFinal : MonoBehaviour
{


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
        if(Selector.seleccionCorrecta)
        {
            Debug.Log("¡Selección correcta!");
        }
        else
        {
            Debug.Log("Selección incorrecta.");
        }
    }
}
