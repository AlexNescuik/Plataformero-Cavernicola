using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{

    public int hp = 100;
    public int hpMax = 100;
    public int score = 0;
    public int vidasIniciales = 2;
    public static int vidas = 2;

    public bool bloqueado = false;

    private Animator miAnimador;
    private Rigidbody2D miCuerpo;
    private Personaje miPersonaje;


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
                print(name + " murió por " + enemigo);
                vidas = vidas - 1;

                if (miPersonaje.tag == "Player")
                {
                    if (vidas <= 0)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                    else
                    {
                        ReiniciarStage();
                    }
                }
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
        vidas = vidas - 1;
        if (miPersonaje.tag == "Player")
        {
            if (vidas <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                ReiniciarStage();
            }
        }
    }

    public void ReiniciarStage()
    {
        string Nivel1 = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(Nivel1);
    }
}
