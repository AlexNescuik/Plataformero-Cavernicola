using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Personaje elPersonaje;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (elPersonaje.estaVivo())
        {
            transform.position = new Vector3(elPersonaje.transform.position.x, elPersonaje.transform.position.y, -1);
        }
    }
}

