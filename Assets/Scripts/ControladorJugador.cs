using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public float velocidadCaminar = 5;
    public float fuerzaSalto = 10f;

    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private EfectosSonoros misSonidos;
    private Personaje miPersonaje;


    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        misSonidos = GetComponent<EfectosSonoros>();
        miPersonaje = GetComponent<Personaje>();
    }

    // Update is called once per frame
    void Update()
    {
        bool puedoMoverme = miPersonaje.estaVivo() && !miPersonaje.bloqueado;


        float velVert = miCuerpo.velocity.y;

        float movHor = Input.GetAxis("Horizontal");

        if (movHor > 0 && puedoMoverme)
        {//der
            transform.rotation = Quaternion.Euler(0, 0, 0);
            miCuerpo.velocity = new Vector3(velocidadCaminar, velVert, 0);
            miAnimador.SetBool("Caminando", true);
        }
        else if (movHor < 0 && puedoMoverme)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            miCuerpo.velocity = new Vector3(-velocidadCaminar, velVert, 0);
            miAnimador.SetBool("Caminando", true);
        }
        else
        {
            miCuerpo.velocity = new Vector3(0, velVert, 0);
            miAnimador.SetBool("Caminando", false);

        }
        if (Input.GetButtonDown("Jump") && puedoMoverme)
        {
            miCuerpo.AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);

            misSonidos.reproducir("salto");
        }
        else if (Input.GetButton("Fire1") && puedoMoverme)
        {
            miAnimador.SetTrigger("GOLPEAR");
        }


        miAnimador.SetFloat("VEL_VERT", velVert);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meta"))
        {
            miAnimador.SetTrigger("Celebrar");
            misSonidos.reproducir("Yippie");
        }
    }
}

        
    

