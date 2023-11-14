using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public ControladorJugador elPerso;
    private Animator miAnimator;

    // Start is called before the first frame update
    void Start()
    {
        miAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject boostrojo = collision.gameObject;

        if (boostrojo.CompareTag("Player"))
        {
            CapsuleCollider2D playerCollider = boostrojo.GetComponent<CapsuleCollider2D>();

            if (playerCollider != null && collision == playerCollider)
            {
                print(name + " detectó colisión con " + boostrojo);

                elPerso = boostrojo.GetComponent<ControladorJugador>();

                if (elPerso != null)
                {
                    elPerso.velocidadCaminar *= 2;
                    miAnimator.SetTrigger("desaparecer");
                    Invoke("restaurarVelocidad", 3);
                    Invoke("destruirObjeto", 1f);
                }
            }
        }
    }

    public void restaurarVelocidad()
    {

        if (elPerso != null)
        {
            elPerso.velocidadCaminar /= 2;
        }
    }


    public void destruirObjeto()
    {
        Destroy(gameObject);
    }

}
