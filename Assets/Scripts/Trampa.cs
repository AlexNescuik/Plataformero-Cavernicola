using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public GameObject sangreDanoPrefab;
    public GameObject coraRotoPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    { //detecta colisión
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {
            print(name + " detecté colisión con " + otroObjeto);

            Personaje elPerso = otroObjeto.GetComponent<Personaje>();
            elPerso.hacerDano(20, this.gameObject);

            GameObject efectoSangre = Instantiate(sangreDanoPrefab);
            efectoSangre.transform.position = elPerso.transform.position;

            if (elPerso.hp < 0)
            {
                GameObject efectoCoraRoto = Instantiate(coraRotoPrefab);
                efectoCoraRoto.transform.position = elPerso.transform.position;
            }
        }
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
