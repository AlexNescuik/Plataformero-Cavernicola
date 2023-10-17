using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public float velocidadCaminar = 5;
    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private EfectosSonoros misSonidos;
    public float fuerzaSalto = 10f;



    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        misSonidos = GetComponent<EfectosSonoros>();
    }

    // Update is called once per frame
    void Update()
    {
        float velVert = miCuerpo.velocity.y;

        float movHor = Input.GetAxis("Horizontal");

        if (movHor > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            miCuerpo.velocity = new Vector3(velocidadCaminar, velVert, 0);
            miAnimador.SetBool("Caminando", true);
        }
        else if (movHor < 0)
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
        if (Input.GetButtonDown("Jump"))
        {
            miCuerpo.AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);

            misSonidos.reproducir("salto");
        }
        else if (Input.GetButton("Fire1"))
        {
            miAnimador.SetTrigger("GOLPEAR");
        }


        miAnimador.SetFloat("VEL_VERT", velVert);


    }
}

        
    

