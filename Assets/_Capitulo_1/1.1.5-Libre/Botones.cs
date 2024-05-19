using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Botones : MonoBehaviour
{
    public GameObject Zona1;
    public GameObject Zona2;
    public GameObject Zona3;

    public GameObject Oscuro; //Este el de las transiciones
    public GameObject Oscurito; //Este es el de inicio de la escena
    public GameObject OscuritoEnd;

    public GameObject CajaTexto;
    private CajitaTexto CajitaTexto;

    public GameObject Bloqueo; //Este el que se activa mientras hay un caja de diálogo activa

    private bool done; //Ha llamado a la policía
    public bool exit; //Y se va
    private bool ending; //para el update

    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        done = false;
        exit = false;
        ending = false;

        CajitaTexto = CajaTexto.GetComponent<CajitaTexto>();

        Zona1.SetActive(true);
        Zona1.transform.GetChild(1).gameObject.SetActive(true);
        // Las demás zonas y sus botones están desactivados

        StartCoroutine(Startt());
    }

    void Update()
    {
        if (exit && !ending)
        {
            ending = true;
            StartCoroutine(Finalizar());
        }
    }

    //  ZONA 1
    public void Zona1_Derecha()
    {
        audioManager.Play("ZoneTransition");
        StartCoroutine(Transicion(1,2));
    }

    public void Zona1_Abajo()
    {
        if (done)
        {
            Bloqueo.SetActive(true);
            CajaTexto.SetActive(true);
            CajitaTexto.nombre = "Amelia";
            CajitaTexto.textLines[0] = "Por aquí se vuelve al hospital.";
            CajitaTexto.textLines[1] = "Debería de volver ya con el Doctor.";
            CajitaTexto.nLines = 2;
        }
        else
        {
            Bloqueo.SetActive(true);
            CajaTexto.SetActive(true);
            CajitaTexto.nombre = "Amelia";
            CajitaTexto.textLines[0] = "Acabo de venir de aquí.";
            CajitaTexto.textLines[1] = "Tengo que buscar la cabina de teléfono.";
            CajitaTexto.nLines = 2;
        }
    }

    public void Zona1_Puerta()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Es la entrada de un bar.";
        CajitaTexto.textLines[1] = "Ya podría el Doctor invitarme un día a tomar algo.";
        CajitaTexto.nLines = 2;
    }

    public void Zona1_Bandera()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Es la bandera de Inglaterra.";
        CajitaTexto.nLines = 1;
    }

    public void Zona1_Buzon()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Un buzón de correos.";
        CajitaTexto.textLines[1] = "No es el momento de ponerse a enviar cartas.";
        CajitaTexto.nLines = 2;
    }

    public void Zona1_Farola()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Es una farola.";
        CajitaTexto.textLines[1] = "No hay mucho más que decir.";
        CajitaTexto.nLines = 2;
    }

    //  ZONA 2
    public void Zona2_Derecha()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "No creo que la cabina este por aquí.";
        CajitaTexto.textLines[1] = "Debería seguir buscando.";
        CajitaTexto.nLines = 2;
    }

    public void Zona2_Izquierda()
    {
        audioManager.Play("ZoneTransition");
        StartCoroutine(Transicion(2,1));
    }

    public void Zona2_Arriba()
    {
        audioManager.Play("ZoneTransition");
        StartCoroutine(Transicion(2,3));
    }

    public void Zona2_Coche()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Vaya, ese coche se parece mucho al del Doctor.";
        CajitaTexto.textLines[1] = "Aunque este está mucho más limpio.";
        CajitaTexto.textLines[2] = "Je je je.";
        CajitaTexto.nLines = 3;
    }

    public void Zona2_Coso()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "¿Cómo se llamará eso que está colgando?";
        CajitaTexto.textLines[1] = "Se lo preguntaré al Doctor más tarde.";
        CajitaTexto.nLines = 2;
    }

    //  ZONA 3
    public void Zona3_Izquierda()
    {
        audioManager.Play("ZoneTransition");
        StartCoroutine(Transicion(3,2));
    }

    public void Zona3_Arbol()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Es un árbol.";
        CajitaTexto.textLines[1] = "...";
        CajitaTexto.textLines[2] = "...";
        CajitaTexto.textLines[3] = "Debería ir a la cabina de teléfono";
        CajitaTexto.nLines = 4;
    }

    public void Zona3_Trabaja()
    {
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Que de hojas tiradas en el suelo.";
        CajitaTexto.textLines[1] = "El jardinero no ha pasado por aquí en un tiempo.";
        CajitaTexto.nLines = 2;
    }

    public void Zona3_Cabin()
    {
        if (done){
            Bloqueo.SetActive(true);
            CajaTexto.SetActive(true);
            CajitaTexto.nombre = "Amelia";
            CajitaTexto.textLines[0] = "Ya he llamado a la policía.";
            CajitaTexto.textLines[1] = "Tengo que volver con el Doctor.";
            CajitaTexto.nLines = 2;

        } else {
            done = true;
            Bloqueo.SetActive(true);
            CajaTexto.SetActive(true);
            CajitaTexto.nombre = "Amelia";
            CajitaTexto.textLines[0] = "Por fin, aquí está la cabina.";
            CajitaTexto.textLines[1] = "...";
            CajitaTexto.textLines[2] = "¿Hola? ¿Comisaría de Policía?";
            CajitaTexto.textLines[3] = "Hemos sufrido un robo en el aparcamiento del hospital.";
            CajitaTexto.textLines[4] = "...";
            CajitaTexto.textLines[5] = "¿Podrían enviar a alguien?";
            CajitaTexto.textLines[6] = "...";
            CajitaTexto.textLines[7] = "Entiendo.";
            CajitaTexto.textLines[8] = "Gracias. Allí estaremos.";
            CajitaTexto.nLines = 9;
        }
    }

    IEnumerator Transicion(int x, int y)
    {
        Oscuro.SetActive(true); //Activo y comienza animación

        switch (x) //Desactivo los botones de la zona actual
        {
            case 1:
                Zona1.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 2:
                Zona2.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 3:
                Zona3.transform.GetChild(1).gameObject.SetActive(false);
                break;
        }

        yield return new WaitForSeconds(1); //Cuando este full negro cambio las zonas

        switch (x)
        {
            case 1:
                Zona1.SetActive(false);
                break;
            case 2:
                Zona2.SetActive(false);
                break;
            case 3:
                Zona3.SetActive(false);
                break;   
        }
        switch (y)
        {
            case 1:
                Zona1.SetActive(true);
                break;
            case 2:
                Zona2.SetActive(true);
                break;
            case 3:
                Zona3.SetActive(true);
                break;
        }

        yield return new WaitForSeconds(1); //Cuando termine la animación activo los botones

        Oscuro.SetActive(false);

        switch (y)
        {
            case 1:
                Zona1.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                Zona2.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                Zona3.transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    IEnumerator Startt(){
        Oscurito.SetActive(true);
        Oscurito.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1.5f);
        Bloqueo.SetActive(true);
        CajaTexto.SetActive(true);
        CajitaTexto.nombre = "Amelia";
        CajitaTexto.textLines[0] = "Debería llamar a la policía...";
        CajitaTexto.textLines[1] = "¿Dónde estará la cabina más cercana?";
        CajitaTexto.textLines[2] = "Será mejor que me ponga en marcha.";
        CajitaTexto.nLines = 3;
        Oscurito.SetActive(false);
    }

    IEnumerator Finalizar(){
        Oscurito.SetActive(true);
        Oscurito.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1.5f);
        OscuritoEnd.SetActive(true);
        SceneManager.LoadScene("_Capitulo_1/1.1.5-Libre/Escena_2");
    }
}
