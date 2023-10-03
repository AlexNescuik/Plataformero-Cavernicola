using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{
    public GameObject splashAguaPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otroObjeto = collision.gameObject;
        if (otroObjeto.tag == "Player")
        {
            Personaje elPerso = otroObjeto.GetComponent<Personaje>();
            elPerso.matarInstantaneamente(this.gameObject);

            GameObject efectoSplash = Instantiate(splashAguaPrefab);
            efectoSplash.transform.position = elPerso.transform.position;
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
