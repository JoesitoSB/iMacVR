using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Collider))]
public class PlaceToSnapController : MonoBehaviour
{
    [SerializeField]
    private TypeSnapableObject typeCanSnap;
    private SnapableObjectController objectPlaced;

    public void Snap(SnapableObjectController _objectToPlace)
    {
        if(!objectPlaced && typeCanSnap == _objectToPlace.GetType())//Check is is not set a objectPlaced and if it is of the same type
        {
            objectPlaced = _objectToPlace;
            //Verificar que sean del mismo tipo y cancelar gravedad
            if(objectPlaced.GetType() == typeCanSnap)
            {
                objectPlaced.GetRigidbody().useGravity = false;
                objectPlaced.gameObject.transform.position = transform.position;
                objectPlaced.gameObject.transform.rotation = transform.rotation;
            }
        }
    }

    public void Drop()
    {
        if(objectPlaced)
        {
            objectPlaced = null;
            objectPlaced.GetRigidbody().useGravity = true;
        }
    }
}
