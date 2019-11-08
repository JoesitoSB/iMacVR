using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class OrientationValidator : MonoBehaviour
{
    [SerializeField]
    private OrientationId id;

    [SerializeField]
    private ObjectOrientationChecker snapOr;


    private void OnTriggerEnter(Collider other)
    {
        var orientationIdentifierObj = other.gameObject.GetComponent<OrientationIdentifier>();
        if (orientationIdentifierObj)
        {
            if(orientationIdentifierObj.getIdentifier() == id)
            {
                snapOr.SetIdentifierValue(id, true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var orientationIdentifierObj = other.gameObject.GetComponent<OrientationIdentifier>();
        if (orientationIdentifierObj)
        {
            if (orientationIdentifierObj.getIdentifier() == id)
            {
                snapOr.SetIdentifierValue(id, true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var orientationIdentifierObj = other.gameObject.GetComponent<OrientationIdentifier>();
        if (orientationIdentifierObj)
        {
            if (orientationIdentifierObj.getIdentifier() == id)
            {
                snapOr.SetIdentifierValue(id, false);
            }
        }
    }
}
