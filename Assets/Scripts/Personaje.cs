using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public int hp = 100;
    public int hpMax = 100;
    public int vidas = 2;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void matarInstantaneamente(GameObject quien)
    {
        print(name + " murió instantaneamente por " + quien);
        hp = 0;
    }

    public void hacerDano(int puntosDano, GameObject enemigo)
    {
        hp = hp - puntosDano;
        print(name + " recibe daño de " + puntosDano + " por " + enemigo);
    }

}
