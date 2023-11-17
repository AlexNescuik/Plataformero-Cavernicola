using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager gameManager;
    private Transform checkPointPos;

    private EfectosSonoros misSonidos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager")?.GetComponent<GameManager>();
        checkPointPos = transform;
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
            print(elPerso.name + " llegó al checkpoint");

            GameManager.ultimoCheckPoint = transform.position;

            misSonidos.reproducir("CheckPoint");
        }
    }
}
