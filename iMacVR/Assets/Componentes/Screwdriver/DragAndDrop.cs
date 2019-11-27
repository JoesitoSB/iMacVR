using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    public bool dragging = false;
    private float distance;


    void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = originalColor;
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
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * .01f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * .01f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.forward * .01f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.back * .01f;
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.position += Vector3.right * .01f;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += Vector3.left * .01f;
        }
    }
}
