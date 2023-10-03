using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorGUI : MonoBehaviour
{

    public Personaje Heroe;
    public Text EtiquetaHPHeroe;
    public Image BarraHPHeroe;
    public Personaje Villano;
    public Text EtiquetaHPVillano;
    public Image BarraHPVillano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //texto hp
        EtiquetaHPHeroe.text = Heroe.hp + "/" + Heroe.hpMax;
        EtiquetaHPVillano.text = Villano.hp + "/" + Villano.hpMax;

        //porcentaje hp
        float porcentajeHPHeroe = Heroe.hp / (float)Heroe.hpMax;
        float porcentajeHPVillano = Villano.hp / (float)Villano.hpMax;

        BarraHPHeroe.fillAmount = porcentajeHPHeroe;
        BarraHPVillano.fillAmount = porcentajeHPVillano;
    }
}
