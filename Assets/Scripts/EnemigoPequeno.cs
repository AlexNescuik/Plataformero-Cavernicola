using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPequeno : MonoBehaviour
{
    public Transform honguito;
    public Transform cavernicola;
    public float velocidadCaminar = 2;
    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private EfectosSonoros misSonidos;
    private bool cerca = false;

    public GameObject sangreDanoPrefab;


    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
    }
    
    //ejecución
    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject enemigo = collision.gameObject;
        if (enemigo.tag == "Player")
        {
            print(enemigo.name + " cerca de " + enemigo);
            cerca = true;

            if (enemigo.transform.position.x < this.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print(collision.gameObject.name + " lejos de " + name);
            cerca = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { //detecta colisión
        print(name + " detecté colisión con " + collision.gameObject);

        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {

            Personaje elPerso = otroObjeto.GetComponent<Personaje>();
            elPerso.hacerDano(20, this.gameObject);
            misSonidos.reproducir("dano");

            GameObject efectoSangre = Instantiate(sangreDanoPrefab);
            efectoSangre.transform.position = elPerso.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cerca)
        {
            miCuerpo.velocity = transform.right * velocidadCaminar;
            miAnimador.SetBool("caminando", true);
        }
        else
        {
            miCuerpo.velocity = Vector3.zero;
            miAnimador.SetBool("caminando", false);
        }
    }

   

}
