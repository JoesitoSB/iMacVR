using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class OrientationChecker : MonoBehaviour
{
    [SerializeField]
    private TestOr testOr;

    [SerializeField]
    private SnapOrientation snapOr;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<OrientationIdentifier>())
        {
            if(other.gameObject.GetComponent<OrientationIdentifier>().getIdentifier() == testOr)
            {
                snapOr.SetIdentifierToTrue(testOr);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<OrientationIdentifier>())
        {
            if (other.gameObject.GetComponent<OrientationIdentifier>().getIdentifier() == testOr)
            {
                snapOr.SetIdentifierToFalse(testOr);
            }
        }
    }
}
