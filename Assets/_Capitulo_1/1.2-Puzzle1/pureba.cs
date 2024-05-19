using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pureba : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Singh;
    public GameObject Amelia;
    public GameObject Dialogo;

    static bool boton1;
    static bool boton2;

    void Start()
    {
        boton1 = true;
        boton2 = false;
    }

    public void clickcaja()
    {
        if (boton1)
        {
            boton1 = false;
            Debug.Log("Click en la caja");

            Amelia.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_Amelia1") as AudioClip;
            Amelia.GetComponent<AudioSource>().Play();

            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(2);

            Invoke("clickcaja2", 5.0f);
        }
    }

    public void clickcaja2()
    {
        Singh.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_DrSingh1") as AudioClip;
        Singh.GetComponent<AudioSource>().Play();

        Dialogo.GetComponent<Dialogue1_2>().escribir(0);

        Invoke("clickcaja3", 3.0f);
    }

    public void clickcaja3()
    {
        Dialogo.SetActive(false);
        boton2 = true;
    }

    public void clickNombre()
    {
        if (boton2)
        {
            boton2 = false;
            Debug.Log("Click en el Nombre ");
            Singh.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_DrSingh2") as AudioClip;
            Singh.GetComponent<AudioSource>().Play();

            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(1);

            Invoke("clickNombre2", 6.0f);
        }
    }

    public void clickNombre2()
    {
        Amelia.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_Amelia2") as AudioClip;
        Amelia.GetComponent<AudioSource>().Play();

        Dialogo.GetComponent<Dialogue1_2>().escribir(3);

        Invoke("clickNombre3", 5.0f);
    }

    public void clickNombre3()
    {
        Amelia.GetComponent<AudioSource>().clip = Resources.Load("Voces/5_Puzle 1/Escena5_DrSingh3") as AudioClip;
        Amelia.GetComponent<AudioSource>().Play();

        Dialogo.GetComponent<Dialogue1_2>().escribir(5);

        Invoke("clickNombre4", 3.0f);
    }

    public void clickNombre4()
    {
        Dialogo.SetActive(false);
    }

    public void resolver()
    {
        if (boton1 || boton2)
        {
            Dialogo.SetActive(true);
            Dialogo.GetComponent<Dialogue1_2>().escribir(4);
        }
        else
        {
            SceneManager.LoadScene("_Capitulo_1/1.2-Puzzle1/Info");
        }
    }
}
