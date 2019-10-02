using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnets : MonoBehaviour
{
    public GameObject[] MagnetTip;
    private bool attached = false;
    private float[] Distance;
    public float SnapTipDistance;
    private GameObject NearGameObject;


    // Start is called before the first frame update
    void Start()
    {
        Distance = new float[MagnetTip.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (!attached)
        {
            NearGameObject = GetTipNearest(MagnetTip);
        }

        float Dist = Vector3.Distance(NearGameObject.transform.position, transform.position);
        if (Dist <= SnapTipDistance)
        {

        }
    }

    private GameObject GetTipNearest(GameObject[] magnets)
    {
        float LastDistance = 0;
        float ActualDistance = 0;
        GameObject NearObject = null;
        for (int i = 0; i < magnets.Length; i++)
        {
            ActualDistance = Vector3.Distance(magnets[i].transform.position, transform.position);
            if (ActualDistance < LastDistance)
            {
                NearObject = magnets[i];
            }

            LastDistance = ActualDistance;
        }

        return NearObject;
    }
}
