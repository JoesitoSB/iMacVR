using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;


    private GameObject collidingObject;
    private GameObject objectInHand;


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

    private void SetCollidingObject(GameObject _collidingObject)
    {
        if (collidingObject || !_collidingObject.GetComponent<Rigidbody>())//Check if already exist a collidingObject or doesn't contains a Rigidbody
        {
            return;
        }
        collidingObject = _collidingObject;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other.gameObject);
    }
    
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other.gameObject);
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)//Review if the collidingObject is empty to don't do anything
        {
            return;
        }
        collidingObject = null;
    }

    private void GrabObject()
    {
        //Set the object in hand and clear the reference of the colliding object
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }
    
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
