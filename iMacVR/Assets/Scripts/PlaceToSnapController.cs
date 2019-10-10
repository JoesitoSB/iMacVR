using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Collider))]
public class PlaceToSnapController : MonoBehaviour
{
    [SerializeField]
    private TypeSnapableObject typeCanSnap;

    public void Snap(SnapableObjectController _objectToPlace)
    {
        
        _objectToPlace.gameObject.transform.position = transform.position;
        //Verificar que sean del mismo tipo y cancelar gravedad
        if(_objectToPlace.GetType() == typeCanSnap)
        {
            _objectToPlace.GetRigidbody().useGravity = false;

        }
    }
}
