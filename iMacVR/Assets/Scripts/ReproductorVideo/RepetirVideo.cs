using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class RepetirVideo : MonoBehaviour
{
    public Image BotonPlay;
    public Sprite PlaySP;
    public VideoPlayer thisvideoplayer;
    private CambiarTiempoVideo _CambiarTiempoVideo = new CambiarTiempoVideo();
    private CambiarSprite _CambiarSprite = new CambiarSprite();

    public void _ReiniciarVideo()
    {
        _CambiarTiempoVideo.AgregarTiempo(thisvideoplayer, -(float)thisvideoplayer.length, -(float)thisvideoplayer.length);
        _CambiarSprite.ChangeSprite(BotonPlay, PlaySP);
    }
}
