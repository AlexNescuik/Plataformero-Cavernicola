using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
    private bool estaCerrado = true;
    private bool estaCerca = false;

    public Image Mouse;

    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private GameObject heroeJugador;

    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        heroeJugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.CompareTag("Player"))
        {
            estaCerca = true;
            MostrarMouse;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.CompareTag("Player"))
        {
            estaCerca = false;
            OcultarMouse;
        }
    }

    private void MostrarMouse()
    {
        
    }

    private void OcultarMouse()
    {

    }

}
