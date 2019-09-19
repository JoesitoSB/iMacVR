using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Collider))]
public class PlaceToSnapController : MonoBehaviour
{
    [SerializeField]
    private TypeSnapableObject typeCanSnap;

    public void Snap(SnapableObject _objectToPlace)
    {
        
        _objectToPlace.gameObject.transform.position = transform.position;
        //_objectToPlace.useGravity = false;{

        //Verificar que sean del mismo tipo y cancelar gravedad
    }
}
