using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector3 ultimoCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.ultimoCheckPoint != Vector3.zero)
        {
            GameObject elPerso = GameObject.FindWithTag("Player");
            elPerso.transform.position = ultimoCheckPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActualizarUltimoCheckpoint(Vector3 nuevaPosicion)
    {
        ultimoCheckPoint = nuevaPosicion;
    }
}
