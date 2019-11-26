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

    public void SetIdentifierValue(OrientationIdentifier _orIdentifier, bool _value = true)
    {
        if (_orIdentifier.getIdentifier() == id)
        {
            snapOr.SetIdentifierValue(id, _value);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    var orientationIdentifierObj = other.gameObject.GetComponent<OrientationIdentifier>();
    //    if (orientationIdentifierObj)
    //    {
    //        SetIdentifierValue(orientationIdentifierObj);
    //        //if(orientationIdentifierObj.getIdentifier() == id)
    //        //{
    //        //    snapOr.SetIdentifierValue(id, true);
    //        //}
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    var orientationIdentifierObj = other.gameObject.GetComponent<OrientationIdentifier>();
    //    if (orientationIdentifierObj)
    //    {
    //        SetIdentifierValue(orientationIdentifierObj);
    //        //if (orientationIdentifierObj.getIdentifier() == id)
    //        //{
    //        //    snapOr.SetIdentifierValue(id, true);
    //        //}
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    var orientationIdentifierObj = other.gameObject.GetComponent<OrientationIdentifier>();
    //    if (orientationIdentifierObj)
    //    {
    //        SetIdentifierValue(orientationIdentifierObj, false);
    //        //if (orientationIdentifierObj.getIdentifier() == id)
    //        //{
    //        //    snapOr.SetIdentifierValue(id, false);
    //        //}
    //    }
    //}
}
