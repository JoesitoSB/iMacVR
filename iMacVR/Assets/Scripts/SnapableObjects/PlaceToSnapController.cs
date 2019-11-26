using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Collider))]
public class PlaceToSnapController : MonoBehaviour
{
    [SerializeField]
    private TypeSnapableObject typeCanSnap;
    [SerializeField]
    private Collision Collision;
    private SnapableObjectController objectPlaced;
    private SnapableObjectController temporalObjectPlaced;


    public TypeSnapableObject GetType()
    {
        return typeCanSnap;
    }

    public void Snap(SnapableObjectController _objectToPlace)
    {
        if(!objectPlaced && typeCanSnap == _objectToPlace.GetType())//Check is is not set a objectPlaced and if it is of the same type
        {
            objectPlaced = _objectToPlace;
            //Verificar que sean del mismo tipo y cancelar gravedad
            if(objectPlaced.GetType() == typeCanSnap)
            {
                Debug.Log("Snaping object: " + objectPlaced.name);
                objectPlaced.isInPlace = true;
                objectPlaced.GetRigidbody().useGravity = false;
                objectPlaced.GetRigidbody().isKinematic = true;
                objectPlaced.GetRigidbody().velocity = new Vector3(0, 0, 0);
                objectPlaced.gameObject.transform.position = transform.position;
                objectPlaced.gameObject.transform.rotation = transform.rotation;
                //Notify the builder manager the piece is 
                MacBuilderManager.instance.SetObjectPlacedValue(objectPlaced.GetType(), true);
            }
        }
    }

    public void Drop()
    {
        if(objectPlaced)
        {
            Debug.Log("Dropped object");
            objectPlaced.GetRigidbody().isKinematic = false;
            objectPlaced.GetRigidbody().useGravity = true;
            MacBuilderManager.instance.SetObjectPlacedValue(objectPlaced.GetType(), false);
            objectPlaced = null;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        temporalObjectPlaced = other.GetComponent<SnapableObjectController>();
        if (temporalObjectPlaced)
        {
            temporalObjectPlaced.SetPlaceToSnap(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(temporalObjectPlaced)
        {
            if(!temporalObjectPlaced.isInPlace) temporalObjectPlaced = other.GetComponent<SnapableObjectController>();
        }else
        {
            temporalObjectPlaced = other.GetComponent<SnapableObjectController>();
        }
        
        if (temporalObjectPlaced)
        {
            temporalObjectPlaced.SetPlaceToSnap(this);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        temporalObjectPlaced = other.GetComponent<SnapableObjectController>();
        if (temporalObjectPlaced)
        {
            if (temporalObjectPlaced.GetType() == typeCanSnap)
            {
                Drop();
                temporalObjectPlaced.SetPlaceToSnap(null);
                temporalObjectPlaced.isInPlace = false;
            }
        }
    }
}
