using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarPartida : MonoBehaviour
{
    public GameObject MenuBorrar;  

    public void BorrarPartida1()
    {
        PlayerPrefs.SetInt("BorrarPartida", 1);
        MenuBorrar.SetActive(true);
    }

    public void BorrarPartida2()
    {
        PlayerPrefs.SetInt("BorrarPartida", 2);
        MenuBorrar.SetActive(true);
    }

    public void BorrarPartida3()
    {
        PlayerPrefs.SetInt("BorrarPartida", 3);
        MenuBorrar.SetActive(true);        
    }
}
