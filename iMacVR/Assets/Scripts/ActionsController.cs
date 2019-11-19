using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean grabActionWithGrip;

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
        var objectInHandRB = objectInHand.GetComponent<Rigidbody>();
        joint.connectedBody = objectInHandRB;
        objectInHandRB.constraints = RigidbodyConstraints.None;
        objectInHandRB.useGravity = true;
        //Debug.LogError("Object in hand: " + objectInHand);
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    public void ReleaseObject()
    {
        var fixedJoint = GetComponent<FixedJoint>();
        var objectInHandRB = objectInHand.GetComponent<Rigidbody>();
        // 1
        if (fixedJoint)
        {
            // 2
            fixedJoint.connectedBody = null;
            Destroy(fixedJoint);
            // 3
            objectInHandRB.velocity = controllerPose.GetVelocity();
            objectInHandRB.angularVelocity = controllerPose.GetAngularVelocity();

        }

        var snapableObjectController = objectInHand.GetComponent<SnapableObjectController>();
        if(snapableObjectController)
        {
            snapableObjectController.Snap();
        }

        // 4
        objectInHand = null;
    }
}
