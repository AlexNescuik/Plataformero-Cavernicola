using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    private EfectosSonoros misSonidos;
    private Animator miAnimador;

    // Start is called before the first frame update
    void Start()
    {
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

            print(name + " llegó a la meta!! " + otro);
            miAnimador.SetTrigger("Meta");
            misSonidos.reproducir("Meta");
        }
    }
}
