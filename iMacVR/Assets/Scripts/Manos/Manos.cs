using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Manos : MonoBehaviour
{
    public SteamVR_Action_Single m_AgarrarAccion = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    public SteamVR_Action_Boolean grabAction;
    
    public Mesh Mano1;
    public Mesh Mano2;
    public Mesh Mano3;
    public Mesh Mano4;
    public Mesh Mano5;
    public Mesh Mano6;
    public Mesh Mano7;
    public Mesh Mano8;

    private void Awake()
    {
        m_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = Mano1;
        }
    }

    private void Agarrar(SteamVR_Action_Single action, SteamVR_Input_Sources source, float axis, float delta)
    {
        Debug.Log("CAMBIAR MANOS");
    }
}
