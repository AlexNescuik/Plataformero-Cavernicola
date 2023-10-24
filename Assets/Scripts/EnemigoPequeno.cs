using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPequeno : MonoBehaviour
{
    public Transform Cavernicola;
    public Transform Honguito;
    public Transform Golem;
    public Transform Rata;
    public Transform Bat;

    public float velocidadCaminar = 2;
    public float rangoAgro = 3;
    public float distanciaAtaque = 2;
    public int puntosDano = 30;
    public bool cerca = false;
    private GameObject heroeJugador;

    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private EfectosSonoros misSonidos;

    public GameObject sangreDanoPrefab;
    public GameObject coraRotoPrefab;


    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();

        heroeJugador = GameObject.FindGameObjectWithTag("Player");
    }
    
    //ejecución

    // Update is called once per frame
    void Update()
    {
        Vector3 miPos = this.transform.position;
        Vector3 posHeroe = heroeJugador.transform.position;
        float distanciaHeroe = (miPos - posHeroe).magnitude;
        if (distanciaHeroe < rangoAgro)
       {
            print(heroeJugador.name + " cerca de " + name);
            cerca = true;

            if (heroeJugador.transform.position.x < this.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            cerca = false;
        }
        if(cerca)
        {
            miCuerpo.velocity = transform.right * velocidadCaminar;
            miAnimador.SetBool("caminando", true);
        }
        else
        {
            miCuerpo.velocity = Vector3.zero;
            miAnimador.SetBool("caminando", false);
        }
        if (distanciaHeroe < distanciaAtaque)
        {
            miAnimador.SetTrigger("GOLPEAR");
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemigoHonguito = collision.gameObject;
        if(enemigoHonguito.tag == "Player")
        {
            print(name + " cerca de " + enemigoHonguito);
            cerca = true;
            Personaje elPerso = enemigoHonguito.GetComponent<Personaje>();
            elPerso.hacerDano(puntosDano, this.gameObject);
        }

        GameObject enemigoGolem = collision.gameObject;
        if (enemigoGolem.tag == "Player")
        {
            print(name + " cerca de " + enemigoGolem);
            Personaje elPerso = enemigoGolem.GetComponent<Personaje>();
            elPerso.hacerDano(puntosDano, this.gameObject);
            cerca = true;
            miAnimador.SetTrigger("GOLPEAR");
        }

        GameObject enemigoRata = collision.gameObject;
        if (enemigoRata.tag == "Player")
        {
            print(name + " cerca de " + enemigoRata);
            cerca = true;
            Personaje elPerso = enemigoRata.GetComponent<Personaje>();
            elPerso.hacerDano(puntosDano, this.gameObject);
            miAnimador.SetTrigger("GOLPEAR");
        }

        GameObject enemigoBat = collision.gameObject;
        if (enemigoBat.tag == "Player")
        {
            print(name + " cerca de " + enemigoBat);
            cerca = true;
            Personaje elPerso = enemigoBat.GetComponent<Personaje>();
            elPerso.hacerDano(puntosDano, this.gameObject);
            miAnimador.SetTrigger("GOLPEAR");
        }
    }
   

}
