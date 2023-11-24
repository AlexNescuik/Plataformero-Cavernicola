using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    private Animator miAnimador;
    private EfectosSonoros misSonidos;

    // Start is called before the first frame update
    void Start()
    {
        misSonidos = GetComponent<EfectosSonoros>();
        miAnimador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject otro = collision.gameObject;
            Personaje elPerso = otro.GetComponent<Personaje>();
            print(otro + " llegó a la meta!! ");
            miAnimador.SetTrigger("Meta");
            misSonidos.reproducir("Meta");
        }
    }
}
