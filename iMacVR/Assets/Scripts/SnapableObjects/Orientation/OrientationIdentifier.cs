﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class OrientationIdentifier : MonoBehaviour
{
    [SerializeField]
    private TestOr testOr;

    public TestOr getIdentifier()
    {
        return testOr;
    }
}
