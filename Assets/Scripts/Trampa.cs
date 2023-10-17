using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public GameObject sangreDanoPrefab;
    public GameObject coraRotoPrefab;
    private EfectosSonoros misSonidos;

    private void OnCollisionEnter2D(Collision2D collision)
    { //detecta colisión
        print(name + " detecté colisión con " + collision.gameObject);

        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {

            Personaje elPerso = otroObjeto.GetComponent<Personaje>();
            elPerso.hacerDano(20, this.gameObject);
            misSonidos.reproducir("dano");

            GameObject efectoSangre = Instantiate(sangreDanoPrefab);
            efectoSangre.transform.position = elPerso.transform.position;

            if (elPerso.hp < 0)
            {
                GameObject efectoCoraRoto = Instantiate(coraRotoPrefab);
                efectoCoraRoto.transform.position = elPerso.transform.position;
                misSonidos.reproducir("muerte");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        misSonidos = GetComponent<EfectosSonoros>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
