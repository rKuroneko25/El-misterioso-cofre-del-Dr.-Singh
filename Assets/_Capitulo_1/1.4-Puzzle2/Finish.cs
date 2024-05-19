using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public List<GameObject> squares; // Lista de los 12 cuadrados
    private List<Vector3> correctPositions = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        correctPositions.Add(new Vector3(-5.04223442f, 2.66089821f, 8.072f));
        correctPositions.Add(new Vector3(-4.04223394f,2.66089821f,8.072f));
        correctPositions.Add(new Vector3(-3.04223442f,2.66089821f,8.072f));
        correctPositions.Add(new Vector3(-5.04223394f,1.65989828f,8.10283375f));
        correctPositions.Add(new Vector3(-4.04223394f,1.65989828f,8.10283375f));
        correctPositions.Add(new Vector3(-3.04223442f, 1.65989828f, 8.10283375f));

        correctPositions.Add(new Vector3(-5.04223442f, 0.668898284f, 8.10283375f));
        correctPositions.Add(new Vector3(-4.04223394f, 0.668898284f, 8.10283375f));
        correctPositions.Add(new Vector3(-3.04223442f, 0.668898284f, 8.10283375f));
        correctPositions.Add(new Vector3(-5.04223394f, -0.315101832f, 8.10283375f));
        correctPositions.Add(new Vector3(-4.04223394f, -0.315101832f, 8.10283375f));
        correctPositions.Add(new Vector3(-3.04223442f, -0.315101832f, 8.10283375f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Comprobar()
    {
        bool allSquaresInCorrectPosition = true; // Asumimos que todos los cuadrados están en la posición correcta

        for (int i = 0; i < squares.Count; i++)
        {
            // Si la posición del cuadrado no está a menos de 1 unidad de la posición correcta, establecemos allSquaresInCorrectPosition en false y salimos del bucle
            if (Vector3.Distance(squares[i].transform.position, correctPositions[i]) > 9f)
            {
                allSquaresInCorrectPosition = false;
                break;
            }
        }

        // Si todos los cuadrados están en la posición correcta, llamamos a NextPhase
        if (allSquaresInCorrectPosition)
        {
            SceneManager.LoadScene("Puzzle1");
        }
    }

}