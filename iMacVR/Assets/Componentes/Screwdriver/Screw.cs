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

    void Update()
    {
        if (TipCol && Tip != null)
        {
            if (Tip.GetComponent<Tip>().Screwing > 0)
            {
                Tip.transform.parent = Hole.transform;
                Tip.GetComponent<Tip>().Screw = true;
                gameObject.GetComponent<Magnets>().attached = false;
                Tip.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Magnets>().DestoryJoint();
                Hole.GetComponent<ProductoPunto>().ScrewTip = true;
            }
            else if (Tip.GetComponent<Tip>().Screwing < 0)
            {
                Tip.GetComponent<Tip>().Screw = false;
                Hole.GetComponent<ProductoPunto>().ScrewTip = false;
            }

            Tip.GetComponent<Tip>().TipUndo = (Tip.GetComponent<Tip>().Screwing * .18f) / 2.9f;
        }
    }

    void FixedUpdate()
    {
        if (Tip != null && TipCol)
        {
            if (Hole.GetComponent<ProductoPunto>().InFront)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Tip.GetComponent<Tip>().Screwing += Time.deltaTime;
                    Hole.transform.localPosition += Vector3.forward * Tip.GetComponent<Tip>().TipUndo;
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    Tip.GetComponent<Tip>().Screwing -= Time.deltaTime;
                    Hole.transform.localPosition -= Vector3.forward * Tip.GetComponent<Tip>().TipUndo;
                }
            }
            
            
            Tip.GetComponent<Tip>().Screwing = Mathf.Clamp(Tip.GetComponent<Tip>().Screwing, -1, 3f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            taladrar();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            destaladrar();
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            TipCol = true;
            if (!other.gameObject.GetComponent<ProductoPunto>().ScrewTip)
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
                Tip = null;
                gameObject.GetComponent<Magnets>().attached = true;
            }
            Hole = null;
        }
    }

    public void taladrar()
    {
        transform.localEulerAngles += new Vector3(0, 1.5f, 0);
    }

    public void destaladrar()
    {
        transform.localEulerAngles -= new Vector3(0, 1.5f, 0);
    }
}
