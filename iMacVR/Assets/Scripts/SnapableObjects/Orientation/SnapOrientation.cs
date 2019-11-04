using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class SnapOrientation : MonoBehaviour
{
    private bool orientation1;
    private bool orientation2;
    private bool orientation3;

    private bool isOriented;

    public bool GetIsOriented()
    {
        return isOriented;
    }

    public void CheckOrientation()
    {
        if(orientation1 == true && orientation2 == true && orientation3 == true)
        {
            //esta en la orientacion correcta y se snapea
            isOriented = true;
        }
        else
        {
            isOriented = false;
        }
    }

    public void SetIdentifierToTrue(TestOr _testOr)
    {
        if(TestOr.O1 == _testOr)
        {
            orientation1 = true;
        }
        if (TestOr.O2 == _testOr)
        {
            orientation2 = true;
        }
        if (TestOr.O3 == _testOr)
        {
            orientation3 = true;
        }

        CheckOrientation();
    }
    public void SetIdentifierToFalse(TestOr _testOr)
    {
        if (TestOr.O1 == _testOr)
        {
            orientation1 = false;
        }
        if (TestOr.O2 == _testOr)
        {
            orientation2 = false;
        }
        if (TestOr.O3 == _testOr)
        {
            orientation3 = false;
        }

        CheckOrientation();
    }
}
