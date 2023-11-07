using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesore : MonoBehaviour
{
    public int valor;

    private Animator miAnimador;
    private EfectosSonoros misSonidos;

    // Start is called before the first frame update
    void Start()
    {
        miAnimador = GetComponent<Animator>();
        misSonidos = GetComponent<EfectosSonoros>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(name + " detecté colisión con " + collision.gameObject);

        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.CompareTag("Player"))
        {
            miAnimador.SetTrigger("DESAPARECER");
            misSonidos.reproducir("moneda");
            Destroy(gameObject, 0.5f);
        }
    }

}
