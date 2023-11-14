using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veneno : MonoBehaviour
{
    private Personaje elPerso;
    private Animator miAnimador;

    public int dano;
    public float duracion = 3f;
    public bool usada;


    // Start is called before the first frame update
    void Start()
    {
        miAnimador = GetComponent<Animator>();
        usada = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {
            usada = true;
            elPerso = otroObjeto.GetComponent<Personaje>();

            if (usada == true)
            {
                InvokeRepeating("danoVeneno", 0, 1);
                Invoke("destruirObjeto", duracion);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        usada = false;
    }

    public void danoVeneno()
    {
        elPerso.hacerDano(dano, this.gameObject);
    }

    public void destruirObjeto()
    {
        Destroy(gameObject, 0.2f);
    }


}
