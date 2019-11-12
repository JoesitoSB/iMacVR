using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReproducirVideo : MonoBehaviour
{
    public VideoPlayer ReproductorDeVideo;
    
    public void PlayPausa()
    {
        if(ReproductorDeVideo.isPlaying)
        {
            ReproductorDeVideo.Pause();
        }
        else
        {
            ReproductorDeVideo.Play();
        }
    }
}
