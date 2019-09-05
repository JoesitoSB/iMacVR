using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/// <summary>
/// Script only for testing purposes
/// </summary>
public class ActionsTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    //Variable to know the physics of the HTC Vive controller
    public SteamVR_Behaviour_Pose controllerPose;
    //Used to know when the controller use the button assigned to grab something
    public SteamVR_Action_Boolean grabAction;
    
    //Object colliding with the HTC Vive controller
    private GameObject collidingObject; // 1
    //Object grabbed
    private GameObject objectInHand; // 2
    
    void Update()
    {
        //Check every frame if the user press the trigger to grab something
        if (grabAction.GetLastStateDown(handType))
        {
            //Review if the colliding object are not empty
            if (collidingObject)
            {
                //If all is correct you can grab the object
                GrabObject();
            }
        }

        //Check every frame if the user release the trigger to grab something
        if (grabAction.GetLastStateUp(handType))
        {
            //Review if the colliding object are not empty
            if (objectInHand)
            {
                //Release object from the "hand"
                ReleaseObject();
            }
        }
    }

    /// <summary>
    /// Used to set the object colliding with the HTC Vive controller (is necesary the object have a RigidBody)
    /// </summary>
    /// <param name="col"></param>
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    /// <summary>
    /// Used to set the grabbed object in your hand
    /// </summary>
    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }
    
    /// <summary>
    /// Create a FixedJoint for the movement of the object
    /// </summary>
    /// <returns></returns>
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    /// <summary>
    /// Reset the "hand", delete the FixedJoint and set the velocity of you give it with the movement of the HTC Vive Controller
    /// </summary>
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        objectInHand = null;
    }

}
