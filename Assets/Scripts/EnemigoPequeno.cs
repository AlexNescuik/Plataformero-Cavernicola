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

    
        // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
    }
    
    //ejecuci�n
    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject otro = collision.gameObject;
        if (otro.tag == "Player")
        {
            print(name + " el enemigo est� cerca " + otro);
            cerca = true;

            if (otro.transform.position.x < this.transform.position.x)
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