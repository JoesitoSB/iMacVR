using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] Musica;
    private AudioSource source;
    private int PistaActual;

    //public Text PistaTiempoTxt;
    public Text PistaNombreTxt;
    
    private int TiempoPista;
    private int TiempoActualDePista;
    private int Segundos;
    private int Minutos;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        //ReproducirMusica();
    }

    public void ReproducirMusica()
    {
        if(!source.isPlaying)
        {
            return;
        }

        PistaActual--;

        if (PistaActual < 0)
        {
            PistaActual = Musica.Length - 1;
        }

        StartCoroutine("EsperarTerminarMusica");
    }

    IEnumerator EsperarTerminarMusica()
    {
        while(source.isPlaying)
        {
            TiempoActualDePista = (int)source.time;
            //MostrarTiempoActualDePista();
            yield return null;
        }
        ProximaCancion();
    }


    public void ProximaCancion()
    {
        source.Stop();
        PistaActual++;
        if (PistaActual > Musica.Length - 1)
        {
            PistaActual = 0;
        }
        Reproducir();
    }

    public void CancionAnterior()
    {
        source.Stop();
        PistaActual--;
        if (PistaActual < 0)
        {
            PistaActual = Musica.Length - 1;
        }
        Reproducir();
    }

    public void PararMusica()                                       //LE PONE PAUSA A LA MUSICA
    {
        Debug.Log("asd");
        if (source.isPlaying)
        {
            StopCoroutine("EsperarTerminarMusica");
            source.Pause();
        }
        else
        {
            //StartCoroutine("EsperarTerminarMusica");
            source.Play();
        }
    }
    
    private void Reproducir()                                       //REPRODUCE LA CANCION
    {
        source.clip = Musica[PistaActual];
        source.Play();
        MostrarDatosDePista();
        //MostrarTiempoActualDePista();
        StartCoroutine("EsperarTerminarMusica");
    }

    void MostrarDatosDePista()
    {
        PistaNombreTxt.text = source.clip.name;
        TiempoPista = (int)source.clip.length;
    }

    /*void MostrarTiempoActualDePista()
    {
        Segundos = TiempoActualDePista % 60;
        Minutos = TiempoActualDePista / 60 % 60;
        PistaTiempoTxt.text = Minutos + ":" + Segundos.ToString("D2") + "/" + ((TiempoPista/60) % 60) + ":" + (TiempoPista % 60).ToString("D2");
    }*/

}
