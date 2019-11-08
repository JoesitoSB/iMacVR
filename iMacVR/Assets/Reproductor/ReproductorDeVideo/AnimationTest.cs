using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public GameObject FotosMenu;
    public Animator AnimationController;
    string end;

    private void Update()
    {
        if(AnimationController.GetCurrentAnimatorStateInfo(0).IsName("CloseVideo") && AnimationController.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && this.gameObject.name == "VideoPlayer")
        {
            Debug.Log("APAGAR VIDEO");
            this.gameObject.SetActive(false);
        }
    }

    public void RunAnimation(string BoolName)
    {
        bool isOpen = AnimationController.GetBool(BoolName);
        FotosMenu.SetActive(true);
        AnimationController.SetBool(BoolName, !isOpen);
    }
}
