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
    private float Segundos;
    private float Minutos;
    public Image BotonPlayPause;
    public Sprite SpritePausa;
    public Sprite SpritePlay;

    //Barra de Tiempo
    public Image TimeBar;
    public Text TiempoActual_Txt;
    public Text TiempoFaltante_Txt;
    public float maxTime;
    public float TiempoRestante;
    public float TiempoActual;
    public bool IsPlaying;
    //


    private CambiarSprite _CambiarSprite = new CambiarSprite();

    void Start()
    {
        TiempoRestante = maxTime;
        TiempoActual = 0;
        PistaNombreTxt.text = Musica[0].name;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsPlaying)
        {
            CorrerTiempo();
            TiempoActual_Txt.text = MostrarTiempoActualDePista(TiempoActual);
            TiempoFaltante_Txt.text = MostrarTiempoActualDePista(TiempoRestante);
        }
        if (TimeBar.fillAmount <= 0)
        {
            ProximaCancion();
        }
    }

    public void CorrerTiempo()                                      //CORRE EL TIEMPO DE LA CANCION
    {
        TiempoRestante -= Time.deltaTime;
        TiempoActual += Time.deltaTime;
        TimeBar.fillAmount = TiempoRestante / maxTime;
    }

    public void ReproducirMusica()                                  //REPRODUCE LA MUSICA
    {
        if (!source.isPlaying)
        {
            return;
        }

        PistaActual--;

        if (PistaActual < 0)
        {
            PistaActual = Musica.Length - 1;
        }
    }

    public void ProximaCancion()                                    //REPRODUCE LA SIGUIENTE CANCION
    {
        source.Stop();
        PistaActual++;
        if (PistaActual > Musica.Length - 1)
        {
            PistaActual = 0;
        }
        Reproducir();
        _CambiarSprite.ChangeSprite(BotonPlayPause, SpritePausa);
        IsPlaying = true;
        maxTime = source.clip.length;
        TiempoRestante = maxTime;
        TiempoActual = 0;
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
        _CambiarSprite.ChangeSprite(BotonPlayPause, SpritePausa);
        IsPlaying = true;
        maxTime = source.clip.length;
        TiempoRestante = maxTime;
        TiempoActual = 0;
    }                               //REPRODUCE LA CANCION ANTERIOR

    public void PararMusica()                                       //LE PONE PAUSA A LA MUSICA
    {
        if (source.isPlaying)
        {
            source.Pause();
            IsPlaying = false;
            _CambiarSprite.ChangeSprite(BotonPlayPause, SpritePlay);
        }
        else
        {
            source.Play();
            IsPlaying = true;
            _CambiarSprite.ChangeSprite(BotonPlayPause, SpritePausa);
        }
    }

    private void Reproducir()                                       //REPRODUCE LA CANCION
    {
        source.clip = Musica[PistaActual];
        source.Play();
        MostrarDatosDePista();
    }

    void MostrarDatosDePista()                                      //TOMA EL NOMBRE Y EL TAMAñO DE LA CANCION;
    {
        PistaNombreTxt.text = source.clip.name;
        TiempoPista = (int)source.clip.length;
    }

    private string MostrarTiempoActualDePista(float _TiempoDePistaActual)   //MUESTRA EL TIEMPO DE LA CANCION
    {
        Segundos = _TiempoDePistaActual % 60;
        Minutos = _TiempoDePistaActual / 60 % 60;
        return string.Format("{0:00}:{1:00}", Minutos, Segundos);
    }
}
