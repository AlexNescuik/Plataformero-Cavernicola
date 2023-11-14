using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Vector3 checkPoint;
    private GameManager gameManager;

    private GameObject otro;

    private EfectosSonoros misSonidos;

    // Start is called before the first frame update
    void Start()
    {
        checkPoint = transform.position;
        misSonidos = GetComponent<EfectosSonoros>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otro = collision.gameObject;
        Personaje elPerso = otro.GetComponent<Personaje>();

        if (otro.tag == "Player" && elPerso.estaVivo())
        {
            print(name + " detectó colisión con " + otro);
            checkPoint = transform.position;
            print(elPerso.name + "llegó al checkpoint");
            GameManager.position
            misSonidos.reproducir("CheckPoint");
        }
    }


}
