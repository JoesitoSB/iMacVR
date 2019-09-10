using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{
    //public SteamVR_Input_Sources handType; // 1
    //public SteamVR_Action_Boolean teleportAction; // 2
    //public SteamVR_Action_Boolean grabAction; // 3

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;


    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2


    // Update is called once per frame
    void Update()
    {
        //Check if the grab action is activated
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        //Check if the grab action is realesed
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    //private void SetCollidingObject(Rigidbody _rb)
    //{
    //    if (collidingObject || !col.GetComponent<Rigidbody>())
    //    {
    //        return;
    //    }
    //    // 2
    //    collidingObject = col.gameObject;
    //}

    //public bool GetTeleportDown() // 1
    //{
    //    return teleportAction.GetStateDown(handType);
    //}

    //public bool GetGrab() // 2
    //{
    //    return grabAction.GetState(handType);
    //}

    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        //Set the object in hand and clear the reference of the colliding  ibject
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        var fixedJoint = GetComponent<FixedJoint>();
        var rb = GetComponent<Rigidbody>();
        if (fixedJoint)
        {
            //Destroy the fixed joint
            fixedJoint.connectedBody = null;
            Destroy(fixedJoint);
            //Add the velocity of the hand
            rb.velocity = controllerPose.GetVelocity();
            rb.angularVelocity = controllerPose.GetAngularVelocity();

        }
        //Delete the object reference in the hand
        objectInHand = null;
    }

}
