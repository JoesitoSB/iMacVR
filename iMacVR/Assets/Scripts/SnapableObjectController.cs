using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Collision), typeof(Rigidbody))]
public class SnapableObjectController : MonoBehaviour
{
    [SerializeField]
    private TypeSnapableObject type;
    [SerializeField]
    private PlaceToSnapController placeToSnap;
    [SerializeField]
    private Rigidbody rb;
    public bool isInPlace { private set; get; }


    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    public TypeSnapableObject GetType()
    {
        return type;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void OnTriggerEnter(Collider other)
    {
        placeToSnap = other.GetComponent<PlaceToSnapController>();
        if(placeToSnap && !isInPlace)
        {
            isInPlace = true;
            placeToSnap.Snap(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        placeToSnap = other.GetComponent<PlaceToSnapController>();
        if (placeToSnap && !isInPlace)
        {
            isInPlace = true;
            placeToSnap.Snap(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(placeToSnap.gameObject == other.gameObject && isInPlace)
        {
            isInPlace = false;
            placeToSnap = null;
            placeToSnap.Drop();
        }
    }
}
