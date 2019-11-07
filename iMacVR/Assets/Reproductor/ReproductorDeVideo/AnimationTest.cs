using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public GameObject FotosMenu;
    public Animator AnimationController;

    private void Update()
    {
        
    }

    public void RunAnimation(string BoolName)
    {
        bool isOpen = AnimationController.GetBool(BoolName);
        FotosMenu.SetActive(true);
        AnimationController.SetBool(BoolName, !isOpen);
    }
}
