using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapaFondoParallax : MonoBehaviour
{
    public float anchoFondo = 20;
    public float anchoCamara = 18;
    public float porcentajeAlcance = 1;

    public float distanciaActualCamara;
    public float diferenciaX;
    private float posXInicial;

    private Transform laCamara;

    // Start is called before the first frame update
    void Start()
    {

        laCamara = Camera.main.transform;
        //mido distancia de inicio
        posXInicial = transform.position.x - this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float xCamaraActual = laCamara.position.x;
        float xCapaActual = transform.position.x;

        diferenciaX = xCamaraActual - posXInicial;
        float distanciaReal = xCamaraActual - xCapaActual;
        float distanciaMax = anchoCamara / 2 + anchoFondo / 2;

        Vector3 posNueva;
        if(distanciaReal > distanciaMax)
        { //se sale de la camara
            float xNueva = xCamaraActual + distanciaMax;
            posNueva = new Vector3(xNueva, transform.position.y, transform.position.z);
            posXInicial = xNueva;
        }
        else
        {
            diferenciaX = xCamaraActual - posXInicial;
            posNueva = new Vector3(xCamaraActual - diferenciaX * porcentajeAlcance, transform.position.y, transform.position.z);
            transform.position = posNueva;
        }

       
    }
}
