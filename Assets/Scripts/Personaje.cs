using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public int hp = 100;
    public int hpMax = 100;
    public int vidas = 2;
    public int score = 0;
    private Animator miAnimador;
    private Rigidbody2D miCuerpo;

    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void hacerDano(int puntosDano, GameObject enemigo)
    {
        hp = hp - puntosDano;
        print(name + " recibe daño de " + puntosDano + " por " + enemigo);
        miAnimador.SetTrigger("DANAR");
        if (hp <= 0)
        {
            miAnimador.SetTrigger("MORIR");
        }
        else
        {
            miAnimador.SetTrigger("DANAR");
        }
    }

    public void matarInstantaneamente(GameObject quien)
    {
        print(name + " murió instantaneamente por " + quien);
        hp = 0;
            miAnimador.SetTrigger("MORIR");
    }

    public void matar(GameObject atacante)
    {
        print(name + " muere a manos de " + atacante);
        hp = 0;
        vidas--;
    }
}
