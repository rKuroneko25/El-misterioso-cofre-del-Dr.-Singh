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
        for (int i = 0; i < squares.Count; i++)
        {
            // Si la posición del cuadrado no es igual a la posición correcta, salimos de la función Update
            if (Vector3.Distance(squares[i].transform.position, correctPositions[i]) > 8.5f)
            {
                return;
            }
        }

        // Si todos los cuadrados están en la posición correcta, pasamos a la siguiente fase
        NextPhase();
    }

    void NextPhase()
    {
        SceneManager.LoadScene("Puzzle1");
    }
}