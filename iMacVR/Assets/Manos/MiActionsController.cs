using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MiActionsController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean triggerAction;

    private GameObject collidingObject;
    public ActionsController Controller;
    private GameObject objectInHand;

    private SnapObjectController snapObjectController;

    public Mesh ManoAbierta;
    public Mesh ManoCerrado;
    public Mesh ManoDedo;
    public Mesh ManoPinch;

    private string GrabState = "Free";

    // Update is called once per frame
    void Update()
    {
        //ABRIR MANO
        if (grabAction.GetLastStateUp(handType) && GrabState == "ManoCerrada")
        {
            CambiarManos(1);
        }

        //CERRAR MANO
        if (grabAction.GetLastStateDown(handType) && GrabState == "Free")
        {
            CambiarManos(2);
        }

        //AGARRARPINCH
        if (triggerAction.GetLastStateDown(handType) && GrabState == "Free")
        {
            CambiarManos(4);
        }
        
        //ABRIR MANO
        if (triggerAction.GetLastStateUp(handType) && GrabState == "Pinch")
        {
            CambiarManos(1);
        }

    }

    public void CambiarManos(int _Poscicion)
    {
        switch (_Poscicion)
        {
            case 1:
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = ManoAbierta;
                GrabState = "Free";
                break;

            case 2:
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = ManoCerrado;
                GrabState = "ManoCerrada";
                break;

            case 3:
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = ManoDedo;
                GrabState = "Dedo";
                break;

            case 4:
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = ManoPinch;
                GrabState = "Pinch";
                break;
        }
    }

    private void GrabObject()
    {
        //Set the object in hand and clear the reference of the colliding object
        objectInHand = collidingObject;
        collidingObject = null;
    }
}
