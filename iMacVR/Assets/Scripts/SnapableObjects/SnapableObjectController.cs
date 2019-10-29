using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Collision), typeof(Rigidbody))]
public class SnapableObjectController : MonoBehaviour
{
    //[SerializeField]
    //private RoboRyanTron.Unite2017.Events.GameEvent ReleaseObjectInHand;
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

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Is in place status " + isInPlace);
        }
    }

    public TypeSnapableObject GetType()
    {
        return type;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public void Snap()
    {
        if (!isInPlace && placeToSnap)
        {
            isInPlace = true;
            placeToSnap.Snap(this);
        }
    }

    public void Drop()
    {
        if(placeToSnap)
        {
            placeToSnap.Drop();//This method control the constrains
            placeToSnap = null;
        }
        isInPlace = false;
    }

    //TODO Añadir metodo para que los objetos snapeables les quite el poder a los controles de moverlos en cuanto se snapean. O sea que los suelte en el instante que se snapean
    private void OnTriggerEnter(Collider other)
    {
        var _placeToSnap = other.GetComponent<PlaceToSnapController>();
        if(_placeToSnap)
        {
            placeToSnap = _placeToSnap;
            //Snap();
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        var place = other.GetComponent<PlaceToSnapController>();
        if (place)
        {
            if (place.GetType() == type)
            {
                placeToSnap.Drop();
                isInPlace = false;
                placeToSnap = null;
            }
        }
        //if (placeToSnap)
        //{
        //    if (placeToSnap.gameObject == other.gameObject)
        //    {
        //        placeToSnap.Drop();
        //        isInPlace = false;
        //        placeToSnap = null;
        //    }
        //}
    }
}
