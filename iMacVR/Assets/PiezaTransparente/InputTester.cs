using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputTester : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject;
    private GameObject objectInHand;

    private SnapObjectController snapObjectController;


    // Update is called once per frame
    void Update()
    {
        //Check if the grab action is activated
        if (grabAction.GetLastStateDown(handType))
        {

        }

        //Check if the grab action is realesed
        if (grabAction.GetLastStateUp(handType))
        {

        }
    }     
}

