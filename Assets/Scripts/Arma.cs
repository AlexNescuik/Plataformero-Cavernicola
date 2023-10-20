using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject arma = collision.gameObject;
        if (arma.tag == "Enemigo")
        {
            print(arma.name + " golpeó a " + name);
            Personaje enemigo = arma.GetComponent<Personaje>();
            enemigo.hacerDano(10, this.gameObject);
            misSonidos.reproducir("danoEne");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
