using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class EfectosSonoros : MonoBehaviour
{
    public Efecto[] misEfectos;
    private AudioSource reproductor;

    void Start()
    {
        reproductor = GetComponent<AudioSource>();
    }

    public void reproducir(string accion)
    {
        foreach (Efecto efec in misEfectos)
        {
            //si la accion del efecto corresponde a la accion solicitada del parametro
            if (efec.accion == accion)
            {
                //asigno sonido al reproductor
                reproductor.clip = efec.sonido;
                reproductor.Play();
                //corto la ejecución
                return;
            }
        }
    }

    [Serializable]

    public class Efecto
    {
        public string accion;
        public AudioClip sonido;        
    }
}
