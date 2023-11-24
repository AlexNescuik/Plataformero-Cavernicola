using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSuave : MonoBehaviour
{
    public Personaje elPersonaje;
    public float offsetProf = -5;
    public float offsetVertical = -1;
    public float velocidadAlcance = 2;

    // LateUpdate is called once per frame after all updates
    void LateUpdate()
    {
        Vector3 posDestino = new Vector3(elPersonaje.transform.position.x, elPersonaje.transform.position.y + offsetVertical, elPersonaje.transform.position.z + offsetProf);
        transform.position = Vector3.Lerp(transform.position, posDestino, Time.deltaTime * velocidadAlcance);
    }



}
