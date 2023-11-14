using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    
    public GameObject Jugador;
    private Vector3 ultimoCheckPoint;



    // Start is called before the first frame update
    void Start()
    {
        GameObject elPerso = GameObject.FindGameObjectWithTag("Player");
        elPerso.transform.position = ultimoCheckPoint;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
