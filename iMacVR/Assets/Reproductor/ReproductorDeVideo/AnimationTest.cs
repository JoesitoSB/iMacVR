using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationTest : MonoBehaviour
{
    public GameObject FotosMenu;
    public Animator AnimationController;
    public VideoPlayer thisvideoplayer;
    string end;

    private void Update()
    {
        if(AnimationController.GetCurrentAnimatorStateInfo(0).IsName("CloseVideo") && AnimationController.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && this.gameObject.name == "VideoPlayer")
        {
            this.gameObject.SetActive(false);
        }

        thisvideoplayer.loopPointReached += VideoFinished;

    }

    public void RunAnimation(string BoolName)
    {
        bool isOpen = AnimationController.GetBool(BoolName);
        FotosMenu.SetActive(true);
        AnimationController.SetBool(BoolName, !isOpen);
    }

    public void VideoFinished(UnityEngine.Video.VideoPlayer vp)
    {
        AnimationController.SetBool("Abrir", false);
    }

}
