using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Animator miAnimador;

    public GameObject mouse;
    public GameObject itemPrefab;

    public bool cerca;


    // Start is called before the first frame update
    void Start()
    {
        mouse.SetActive(false);
        miAnimador = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && cerca && itemPrefab != null)
        {
            miAnimador.SetTrigger("abrir");

            Vector3 cofrePosition = transform.position;
            GameObject newItem = Instantiate(itemPrefab, cofrePosition, Quaternion.identity);

            Invoke("destruirObjeto", 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otro = collision.gameObject;
        Personaje elPerso = otro.GetComponent<Personaje>();


        if (otro.tag == "Player" && elPerso.estaVivo())
        {
            print(name + " detectó colisión con " + otro);
            mouse.SetActive(true);

            cerca = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject otro = collision.gameObject;
        Personaje elPerso = otro.GetComponent<Personaje>();

        if (otro.tag == "Player" && elPerso.estaVivo())
        {
            mouse.SetActive(false);

            cerca = false;
        }
    }

    private void destruirObjeto()
    {
        Destroy(gameObject);
    }
}
