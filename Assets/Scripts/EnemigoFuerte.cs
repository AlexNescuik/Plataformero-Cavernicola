using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFuerte : MonoBehaviour
{
    public Transform Cavernicola;
    public Transform Hongo;

    public float velocidadCaminar = 5;
    private bool cerca = false;
    private bool lejos;
    public float distanciaAtaque = 3;
    public float rangoAgro = 3;

    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private EfectosSonoros misSonidos;
    private GameObject heroeJugador;

    public GameObject SangrePrefab;
    public GameObject corazonRotoPrefab;

    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        heroeJugador = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()

    {
        Vector3 miPos = this.transform.position;
        Vector3 posHeroe = heroeJugador.transform.position;
        float distanciaHeroe = (miPos - posHeroe).magnitude;

        if (distanciaHeroe < rangoAgro)
        {
            cerca = true;
        }
        else
        {
            cerca = false;
        }

        if (distanciaHeroe < distanciaAtaque)
        {
            miAnimador.SetTrigger("GOLPEAR");
            miAnimador.SetBool("caminando", false);
        }


        if (cerca == true)
        {
            if (Cavernicola.position.x < Hongo.position.x)
            {
                transform.rotation =
                Quaternion.Euler(0, 180, 0);
                miCuerpo.velocity =
                    new Vector3(-velocidadCaminar, 0, 0);
                miAnimador.SetBool("caminando", true);
            }

            else if (Hongo.position.x < Cavernicola.position.x)
            {
                transform.rotation =
                               Quaternion.Euler(0, 0, 0);
                miCuerpo.velocity =
                   new Vector3(velocidadCaminar, 0, 0);
                miAnimador.SetBool("caminando", true);
            }
        }
        else
        {
            miAnimador.SetBool("caminando", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { //Este metodo se ejecuta cuando este objeto detecta una colision
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {
            print(name + " detecte colision con " + otroObjeto);

            //Con estas instrucciones obtengo el componente Personaje del Player 
            Personaje elPerso = otroObjeto.GetComponent<Personaje>();

            //Con esto le mando daño al personaje por 20 puntos y le digo que objeto fue el que lo daño
            elPerso.hacerDano(20, this.gameObject);

            //Sangre efecto
            GameObject efectoDeSangre = Instantiate(SangrePrefab);
            efectoDeSangre.transform.position = elPerso.transform.position;

            //Corazon roto
            if (elPerso.hp < 1)
            {
                GameObject efectoCorazon = Instantiate(corazonRotoPrefab);
                efectoCorazon.transform.position = elPerso.transform.position;
            }
        }
    }
}