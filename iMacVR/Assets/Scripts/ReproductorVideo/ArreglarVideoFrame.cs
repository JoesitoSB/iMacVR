using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ArreglarVideoFrame : MonoBehaviour
{
    public VideoPlayer ReproductorDeVideo;

    public void RegresarAFirstFrame()
    {
        ReproductorDeVideo.loopPointReached += EndReached;
        
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        ReproductorDeVideo.frame = 0;
    }


}
