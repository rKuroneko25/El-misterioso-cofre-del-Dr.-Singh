using System.Collections;
using System.Collections.Generic;
using uLipSync;
using UnityEngine;


public class BakedDataTest : MonoBehaviour
{
    public GameObject lipSyncComp;

    public BakedData data;

    private uLipSyncBakedDataPlayer bakedPlayer;

    void Start()
    {
        bakedPlayer = lipSyncComp.GetComponent<uLipSyncBakedDataPlayer>(); 
    }

    void Update()
    {
        if (!bakedPlayer.isPlaying)
        {
            bakedPlayer.Play(data);
        }
        
    }
}
