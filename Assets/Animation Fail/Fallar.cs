using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallar : MonoBehaviour
{

    public GameObject failed;

    public void fail()
    {
        //Encontrar un objeto con la tag fail
        failed.SetActive(true);
        GameObject failText = failed.transform.GetChild(0).gameObject;
        failText.GetComponent<Animator>().SetTrigger("fail");

        GameObject blur = failed.transform.GetChild(1).gameObject;
        blur.GetComponent<Animator>().SetTrigger("blur");

        Invoke("rest", 1.25f);
    }

    public void rest()
    {
        GameObject elresto = failed.transform.GetChild(2).gameObject;
        elresto.SetActive(true);
        elresto.GetComponent<Animator>().SetTrigger("rest");
    }
}
