using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class handtest : MonoBehaviour
{
    public SteamVR_Action_Single m_AgarrarAccion = null;

    private Animator m_Animator = null;
    private SteamVR_Behaviour_Pose m_Pose = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();

        m_AgarrarAccion[m_Pose.inputSource].onChange += Agarrar;
    }

    private void OnDestroy()
    {
        m_AgarrarAccion[m_Pose.inputSource].onChange -= Agarrar;
    }

    private void Agarrar(SteamVR_Action_Single action, SteamVR_Input_Sources source, float axis, float delta)
    {
        m_Animator.SetFloat("AgarrarBlend", axis);
    }

}
