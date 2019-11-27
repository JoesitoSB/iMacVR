using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GetCurrentVideoFrame : MonoBehaviour
{
    public VideoPlayer thisvideoplayer;

    private void Update()
    {
        thisvideoplayer.loopPointReached += VideoFinished;
    }

    public void VideoFinished(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("VIDEO SE ACAVO");
    }

}
