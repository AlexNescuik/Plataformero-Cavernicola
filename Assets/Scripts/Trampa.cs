using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    { //detecta colisión
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {
            print(name + " detecté colisión " + otroObjeto);
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
