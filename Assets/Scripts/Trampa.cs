using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    { //detecta colisi�n
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {
            print(name + " detect� colisi�n " + otroObjeto);
        }

        Personaje elPerso = otroObjeto.GetComponent<Personaje>();

        elPerso.hacerDano(20, this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
