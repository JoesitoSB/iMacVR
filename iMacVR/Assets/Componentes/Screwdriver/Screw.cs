using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditorInternal;
using UnityEngine;
using Valve.VR;

public class Screw : MonoBehaviour
{
    [SerializeField]
    private GameObject Tip = null;
    [SerializeField]
    private GameObject Hole = null;
    private bool TipCol = false;

    //[SerializeField]
    //private float screwing = -0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (TipCol)
        {

            if (Tip.GetComponent<Tip>().Screwing > 0)
            {
                Tip.transform.parent = Hole.transform;
                Tip.GetComponent<Tip>().Screw = true;
                gameObject.GetComponent<Magnets>().attached = false;
                
            }
            else if (Tip.GetComponent<Tip>().Screwing < 0)
            {
                if (Tip != null)
                {
                    Tip.GetComponent<Tip>().Screw = false;
                    
                }
            }

            Tip.GetComponent<Tip>().TipUndo = (Tip.GetComponent<Tip>().Screwing * .18f) / 2.9f;
        }
    }

    void FixedUpdate()
    {
        if (Tip != null && TipCol)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Tip.GetComponent<Tip>().Screwing += Time.deltaTime;
                //if (Tip.GetComponent<Tip>().Screwing < 5)
                //{
                //    //Vector3 foraward = Hole.transform.TransformDirection(Vector3.forward);
                //    //Hole.transform.localPosition = new Vector3(Hole.transform.localPosition.x,
                //    //    Hole.transform.position.y, Hole.transform.position.z + Tip.GetComponent<Tip>().TipUndo);
                //}
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Tip.GetComponent<Tip>().Screwing -= Time.deltaTime;
                //if (Tip.GetComponent<Tip>().Screwing > 0)
                //{
                //    Hole.transform.position += Vector3.forward*0.01f;
                //}
                
            }
            //Hole.transform.localPosition = new Vector3(Hole.transform.position.x,
            //    Hole.transform.position.y, Tip.GetComponent<Tip>().TipUndo);
            Hole.transform.localPosition = Vector3.forward * Tip.GetComponent<Tip>().TipUndo;
            Tip.GetComponent<Tip>().Screwing = Mathf.Clamp(Tip.GetComponent<Tip>().Screwing, -1, 3f);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            TipCol = true;
            if (other.gameObject.transform.childCount <= 0)
            {
                if (gameObject.GetComponent<Magnets>().attached)
                {
                    Tip = gameObject.GetComponent<Magnets>().NearGameObject;
                }
            }
            else
            {
                if (gameObject.GetComponent<Magnets>().attached)
                {
                    Tip = null;
                }
                else
                {
                    Tip = other.gameObject.transform.GetChild(0).gameObject;
                }
            }

            Hole = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            TipCol = false;
            if (Tip.GetComponent<Tip>().Screwing < 0 && Tip != null)
            {
                Tip.transform.parent = transform;
                Tip = null;
                gameObject.GetComponent<Magnets>().attached = true;
            }
            Hole = null;
        }
    }
}
