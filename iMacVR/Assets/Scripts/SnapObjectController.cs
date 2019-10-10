using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnapObjectController : MonoBehaviour
{
    [SerializeField]
    private GameObject snaptarget;
    private Rigidbody rb;
    private bool isPlaced;

    private const string SNAPTARGETTAG = "SnapTarget";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//Get the Rigidbody component and save it in the variable "rb"
    }

    //Review is the object is placed and if is true keep the object in place
    private void CheckIfIsPlaced()
    {
        if (isPlaced && snaptarget)
        {//if the module has been placed, it will maintain the posicion of the placeholder
            rb.velocity = Vector3.zero;
            transform.position = snaptarget.transform.position;
            transform.rotation = snaptarget.transform.rotation;
            rb.useGravity = false;
        }
    }

    public void ReleaseObject()
    {
        if (snaptarget)
        {
            isPlaced = true;
            rb.velocity = Vector3.zero;
        }
        else
        {
            isPlaced = false;
            rb.useGravity = true;
        }

        CheckIfIsPlaced();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == SNAPTARGETTAG)
        {//Assigns the placeholder gameobject when enter the trigger
            snaptarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == SNAPTARGETTAG)
        {//Sets the placeholder gameobject to null when leaving the trigger
            snaptarget = null;
            rb.useGravity = true;
        }
    }

    //[SerializeField]
    //private GameObject snaptarget;
    //private Rigidbody rb;
    //private bool isPlaced;

    //private const string SNAPTARGETTAG = "SnapTarget";

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();//Get the Rigidbody component and save it in the variable "rb"
    //}
}
