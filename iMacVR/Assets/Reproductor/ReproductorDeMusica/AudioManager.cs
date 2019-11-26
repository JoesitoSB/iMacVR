using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public CancionesClass[] Canciones;

    #region Variables Privadas
    private AudioSource source;
    private int TiempoPista;
    private int PistaActual;
    private int TiempoActualDePista;
    private float Segundos;
    private float Minutos;
    private float maxTime;
    private float TiempoRestante;
    private float TiempoActual;
    private bool IsPlaying;
    #endregion

    #region Textos
    [Header("Textos")]
    public Text PistaNombreTxt;
    public Text ArtistaNombreTxt;
    public Text TiempoActual_Txt;
    public Text TiempoFaltante_Txt;
    #endregion

    #region Imagenes
    [Header("Imagenes")]
    public Image BotonPlayPause;
    public Image AlbumArtIMG;
    public Image TimeBar;
    #endregion

    #region Sprites
    [Header ("Sprites")]
    public Sprite SpritePausa;
    public Sprite SpritePlay;
    public Sprite DefaultAlbumArt;
    #endregion
    

    private CambiarSprite _CambiarSprite = new CambiarSprite();

    void Start()
    {
        TiempoRestante = maxTime;
        TiempoActual = 0;
        PistaNombreTxt.text = Canciones[0].Nombre;
        ArtistaNombreTxt.text = Canciones[0].Artista;
        source = GetComponent<AudioSource>();
        CambiarArte(0);
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

    public void CorrerTiempo()                                              //CORRE EL TIEMPO DE LA CANCION
    {
        TiempoRestante -= Time.deltaTime;
        TiempoActual += Time.deltaTime;
        TimeBar.fillAmount = TiempoRestante / maxTime;
    }
    
    public void ProximaCancion()                                            //REPRODUCE LA SIGUIENTE CANCION
    {
        source.Stop();
        PistaActual++;
        if (PistaActual > Canciones.Length - 1)
        {
            PistaActual = 0;
        }
        ReproducirCancion(PistaActual);
        _CambiarSprite.ChangeSprite(BotonPlayPause, SpritePausa);
        IsPlaying = true;
        CambiarArte(PistaActual);
        maxTime = source.clip.length;
        TiempoRestante = maxTime;
        TiempoActual = 0;
    }

    public void CancionAnterior()                                           //REPRODUCE LA CANCION ANTERIOR
    {
        source.Stop();
        PistaActual--;
        if (PistaActual < 0)
        {
            PistaActual = Canciones.Length - 1;
        }
        ReproducirCancion(PistaActual);
        _CambiarSprite.ChangeSprite(BotonPlayPause, SpritePausa);
        IsPlaying = true;
        CambiarArte(PistaActual);
        maxTime = source.clip.length;
        TiempoRestante = maxTime;
        TiempoActual = 0;
    }

    public void PararMusica()                                               //LE PONE PAUSA A LA MUSICA
    {
        Debug.Log("asd");
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

    private void CambiarArte(int _cancionNum)                               //LE CAMBIA LA IMAGEN DEL ALBUM ART
    {
        if(Canciones[_cancionNum].AlbumArt == null)
        {
            AlbumArtIMG.sprite = DefaultAlbumArt;
        }

        else
        {
            AlbumArtIMG.sprite = Canciones[_cancionNum].AlbumArt;
        }
    }
    
    public void ReproducirCancion(int _cancionNum)                          //REPRODUCE LA MUSICA
    {
        source.clip = Canciones[_cancionNum].Cancion;
        PistaNombreTxt.text = Canciones[_cancionNum].Nombre;
        ArtistaNombreTxt.text = Canciones[_cancionNum].Artista;
        TiempoPista = (int)source.clip.length;
        source.Play();
    }                       

    private string MostrarTiempoActualDePista(float _TiempoDePistaActual)   //MUESTRA EL TIEMPO DE LA CANCION
    {
        Segundos = _TiempoDePistaActual % 60;
        Minutos = _TiempoDePistaActual / 60 % 60;
        return string.Format("{0:00}:{1:00}", Minutos, Segundos);
    }
}
