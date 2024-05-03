using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    private Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();

        if(PlayerPrefs.GetInt("FullScreen")==1)
        {
            Screen.fullScreen = true;    
            toggle.isOn = true;
        }
        else{
            Screen.fullScreen = false;
            toggle.isOn = false;
        }
    }

    public void ChangeFullScreen()
    {
        Screen.fullScreen = toggle.isOn;
        PlayerPrefs.SetInt("FullScreen", toggle.isOn ? 1 : 0);
    }
}
