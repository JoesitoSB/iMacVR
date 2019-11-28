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
        Debug.Log("SNAP PROCES");
        Debug.Log("Is any obj placed: " + objectPlaced);
        Debug.Log("Type can snap: " + typeCanSnap);
        Debug.Log("Type os the object to snap: " + _objectToPlace.GetType());
        if(!objectPlaced && typeCanSnap == _objectToPlace.GetType())//Check is is not set a objectPlaced and if it is of the same type
        {
            objectPlaced = _objectToPlace;
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
        Debug.LogWarning("Object col: " + other.name + ", type of the current place to snap: " + typeCanSnap);
        temporalObjectPlaced = other.GetComponent<SnapableObjectController>();
        if (temporalObjectPlaced)
        {
            temporalObjectPlaced.SetPlaceToSnap(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (temporalObjectPlaced)
        {
            if (temporalObjectPlaced.gameObject != other.gameObject)
            {
                var auxTemporalObjectPlaced = other.GetComponent<SnapableObjectController>();
                if (auxTemporalObjectPlaced)
                {
                    temporalObjectPlaced = auxTemporalObjectPlaced;
                    temporalObjectPlaced.SetPlaceToSnap(this);
                }
            }
        }
        else
        {
            var auxTemporalObjectPlaced = other.GetComponent<SnapableObjectController>();
            if (auxTemporalObjectPlaced)
            {
                temporalObjectPlaced = auxTemporalObjectPlaced;
                temporalObjectPlaced.SetPlaceToSnap(this);
            }
        }
        //if (temporalObjectPlaced)
        //{
        //    if(!temporalObjectPlaced.isInPlace) temporalObjectPlaced = other.GetComponent<SnapableObjectController>();
        //}else
        //{
        //    temporalObjectPlaced = other.GetComponent<SnapableObjectController>();
        //}
        
        //if (temporalObjectPlaced)
        //{
        //    temporalObjectPlaced.SetPlaceToSnap(this);
        //}
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
