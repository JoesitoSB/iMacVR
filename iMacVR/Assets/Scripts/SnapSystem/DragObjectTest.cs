using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectTest : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private float mZOffset;

    public Transform snaptarget;

    private Rigidbody rb;
    public bool isPlaced;

    private void Update()
    {
        if( snaptarget)
        {
            transform.position = snaptarget.position;
        }
    }

    public void OnMouseDown()
    {
        
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            isPlaced = false;
        
    }
    public void OnMouseDrag()
    {
        //if (!snaptarget)
        //{
        //    transform.position = GetMouseWorldPos() + mOffset;
        //}
        transform.position = GetMouseWorldPos() + mOffset;

    }
    public void OnMouseUp()
    {
        if(snaptarget)
        {
            Debug.Log(transform.position);
            transform.position = new Vector3(0,0 ,0 );
            Debug.Log(transform.position);
                
            isPlaced = true;
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mZCoord += GetDistance();
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SnapTarget")
        {
            snaptarget = gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SnapTarget")
        {
            snaptarget = null;
        }
    }



}
