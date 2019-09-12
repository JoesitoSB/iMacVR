using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectTest : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private float mZOffset;

    public GameObject snaptarget;

    private Rigidbody rb;
    public bool isPlaced;
    

    

    //this function make references to the variables
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if the module has been place, it will maintain the posicion of the placeholder
        if(isPlaced && snaptarget)
        {
            transform.position = snaptarget.transform.position;
            transform.rotation = snaptarget.transform.rotation;
            rb.useGravity = false;
        }
    }

    /// <summary>
    /// This part will be replaced with the drag and drop Vr code
    /// </summary>
    public void OnMouseDown()
    {
           
        //this variable are for the if statement in the Update function and also enable gravity so the module falls down if the user dont grab it
        isPlaced = false;
        rb.useGravity = true;


        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        
    }
    //This part will be replaced with the drag and drop Vr code
    public void OnMouseDrag()
    {
        //if (!snaptarget)
        //{
        //    transform.position = GetMouseWorldPos() + mOffset;
        //}
        transform.position = GetMouseWorldPos() + mOffset;

    }
    //This part will be replaced with the drag and drop Vr code
    public void OnMouseUp()
    {
        if(snaptarget)
        {
            //This variables are for the if statement in the Update function and also disables gravity so the module wont fall down
            isPlaced = true;
            rb.velocity = Vector3.zero;

        }
    }

    //his part will be replaced with the drag and drop Vr code
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mZCoord += GetDistance();
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    //his part will be replaced with the drag and drop Vr code
    private float GetDistance()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)//forward
        {
            return .2f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            return -.2f;
        }
        else
        {
            return 0;
        }       
    }

    //asigns the placeholder gameobject when enter the trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SnapTarget")
        {
            snaptarget = other.gameObject;
        }
    }
    //sets the placeholder gameobject to null when leaving the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SnapTarget")
        {
            snaptarget = null;
        }
    }


    
}
