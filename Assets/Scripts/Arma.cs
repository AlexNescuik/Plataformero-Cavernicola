using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public int puntosAtaque = 30;
    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private EfectosSonoros misSonidos;
    public GameObject sangreDanoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        misSonidos = GetComponent<EfectosSonoros>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otro = collision.gameObject;
        print(" Arma " + name + " golpeó a " + otro);

        if (otro.tag == "Enemigo")
        { 
            Personaje elPerso = otro.GetComponent<Personaje>();
            elPerso.hacerDano(puntosAtaque, this.gameObject);
            misSonidos.reproducir("danoEne");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
