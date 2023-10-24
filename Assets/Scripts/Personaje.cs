using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public int hp = 100;
    public int hpMax = 100;
    public int vidas = 2;
    public int score = 0;

    public bool bloqueado = false;

    private Animator miAnimador;
    private Rigidbody2D miCuerpo;
    private Personaje miPersonaje;
    public static int vida;


    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        miPersonaje = GetComponent<Personaje>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool estaVivo()
    {
        return hp > 0;

    }

    private void desbloquear()
    {
        bloqueado = false;
    }

    public void hacerDano(int puntosDano, GameObject enemigo)
    {
        bool puedoMoverme = miPersonaje.estaVivo() && !miPersonaje.bloqueado;

        if (miPersonaje.estaVivo())
        {

            hp = hp - puntosDano;
            bloqueado = true;
            //durante 1.2 segs e va a ejecutar un método llamado "desbloquear"
            Invoke("desbloquear", 1.2f);

            print(name + " recibe daño de " + puntosDano + " por " + enemigo);
            miAnimador.SetTrigger("DANAR");
            if (hp <= 0)
            {
                miAnimador.SetTrigger("MORIR");
                vidas--;
            }
            else
            {
                miAnimador.SetTrigger("DANAR");
            }
        }
    }
        public void matarInstantaneamente(GameObject quien)
        {
            print(name + " murió instantaneamente por " + quien);
            hp = 0;
            miAnimador.SetTrigger("MORIR");
        }

}
