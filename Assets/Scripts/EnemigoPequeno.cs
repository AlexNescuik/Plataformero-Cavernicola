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
    private bool cerca;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemigo = collision.gameObject;
        if (enemigo.tag == "Player")
        {
            print(name + " el enemigo está cerca " +  enemigo);
            cerca = true;

        }
             
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject enemigo = collision.gameObject;
        if (enemigo.tag == "Player")
        {
            print(name + " el enemigo está lejos " + enemigo);
            cerca = false;
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float velVert = miCuerpo.velocity.y;
        if (cerca == true)
        {
            if (cavernicola.position.x < honguito.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                miCuerpo.velocity = new Vector3(-velocidadCaminar, 0, 0);
                miAnimador.SetBool("Caminando", true);
            }
            else if (honguito.position.x < cavernicola.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                miCuerpo.velocity = new Vector3(velocidadCaminar, 0, 0);
                miAnimador.SetBool("Caminando", true);
                
            }
            else
            {
                miCuerpo.velocity = new Vector3(0, velVert, 0);
                miAnimador.SetBool("Caminando", false);
            }
        }
        miAnimador.SetFloat("VEL_VERT", velVert);
    }

}
