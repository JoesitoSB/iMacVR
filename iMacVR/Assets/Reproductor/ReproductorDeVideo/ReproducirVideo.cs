using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReproducirVideo : MonoBehaviour
{
    public VideoPlayer ReproductorDeVideo;
    public Image BotonPlayPause;
    public Sprite PlaySP;
    public Sprite PauseSP;

    private CambiarSprite _CambiarSprite = new CambiarSprite();
    private CambiarTiempoVideo _CambiarTiempoVideo = new CambiarTiempoVideo();

    public void PlayPausa()
    {
        if(ReproductorDeVideo.isPlaying)
        {
            ReproductorDeVideo.Pause();
            _CambiarSprite.ChangeSprite(BotonPlayPause, PlaySP);
        }
        else
        {
            ReproductorDeVideo.Play();
            _CambiarSprite.ChangeSprite(BotonPlayPause, PauseSP);
        }
    }

    public void CambiarTiempoVideo(float _TimeSkip)
    {
        _CambiarTiempoVideo.AgregarTiempo(ReproductorDeVideo, _TimeSkip);
    }
}
