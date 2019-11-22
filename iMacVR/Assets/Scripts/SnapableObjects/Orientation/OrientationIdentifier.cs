﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class OrientationIdentifier : MonoBehaviour
{
    [SerializeField]
    private OrientationId id;
    private OrientationValidator orientationValidatorObj;

    public OrientationId getIdentifier()
    {
        return id;
    }

    private void OnTriggerEnter(Collider other)
    {
        orientationValidatorObj = other.gameObject.GetComponent<OrientationValidator>();
        if (orientationValidatorObj)
        {
            orientationValidatorObj.SetIdentifierValue(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(orientationValidatorObj) orientationValidatorObj = other.gameObject.GetComponent<OrientationValidator>();
        if (orientationValidatorObj)
        {
            orientationValidatorObj.SetIdentifierValue(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        orientationValidatorObj = other.gameObject.GetComponent<OrientationValidator>();
        if (orientationValidatorObj)
        {
            orientationValidatorObj.SetIdentifierValue(this, false);
        }
        orientationValidatorObj = null;
    }
}
