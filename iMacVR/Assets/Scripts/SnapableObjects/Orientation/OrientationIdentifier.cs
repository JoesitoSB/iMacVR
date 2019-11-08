using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class OrientationIdentifier : MonoBehaviour
{
    [SerializeField]
    private OrientationId id;

    public OrientationId getIdentifier()
    {
        return id;
    }
}
