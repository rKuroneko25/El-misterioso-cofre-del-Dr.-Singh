using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_Testing : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LD_LineController lineController;

    // Start is called before the first frame update
    private void Start()
    {
        lineController.SetUpLine(points);
    }
}
