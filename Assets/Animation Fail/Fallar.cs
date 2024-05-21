using UnityEngine;
using UnityEngine.SceneManagement;

public class Fallar : MonoBehaviour
{

    public GameObject failed;
    private AudioManager2 audioManager;

    public string scene;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager (SFX)").GetComponent<AudioManager2>();
    }

    public void fail()
    {
        //Encontrar un objeto con la tag fail
        failed.SetActive(true);
        GameObject failText = failed.transform.GetChild(1).gameObject;
        failText.GetComponent<Animator>().SetTrigger("fail");

        GameObject blur = failed.transform.GetChild(0).gameObject;
        blur.GetComponent<Animator>().SetTrigger("blur");

        audioManager.Play("Bum");

        Invoke("rest", 1.25f);
    }

    public void rest()
    {
        GameObject elresto = failed.transform.GetChild(2).gameObject;
        elresto.SetActive(true);
        elresto.GetComponent<Animator>().SetTrigger("rest");
    }

    public void restart()
    {
        SceneManager.LoadScene(scene);
    }

    public void title()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
