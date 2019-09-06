using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Color mouseOverColor = Color.green;
    private Color originalColor = Color.red;
    Rigidbody ThisRigibody;
    private bool dragging = false;
    private float distance;
    public GameObject Other;
    private ObiRigidbody otherRigidbody;
    private ObiRigidbody thisobiObiRigidbody;
    public bool holding;

    private void Start()
    {
        ThisRigibody = GetComponent<Rigidbody>();
        otherRigidbody = Other.GetComponent<ObiRigidbody>();
        thisobiObiRigidbody = GetComponent<ObiRigidbody>();
        otherRigidbody.kinematicForParticles = false;
        thisobiObiRigidbody.kinematicForParticles = false;
        //ThisRigibody.constraints = RigidbodyConstraints.FreezePosition;
    }
    
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
            holding = true;
            //ThisRigibody.constraints = RigidbodyConstraints.FreezePositionY;
            //thisobiObiRigidbody.kinematicForParticles = true;
            //otherRigidbody.kinematicForParticles = false;

            //ThisRigibody.useGravity = false;
            //otherRigidbody.constraints = RigidbodyConstraints.None;
        }
        else
        {
            holding = false;
            //ThisRigibody.constraints = RigidbodyConstraints.None;
            //otherRigidbody.kinematicForParticles = false;
            //thisobiObiRigidbody.kinematicForParticles = false;

            //ThisRigibody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            //otherRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            ////ThisRigibody.constraints = RigidbodyConstraints.FreezePositionZ;
            //ThisRigibody.useGravity = true;
        }

    }
}
