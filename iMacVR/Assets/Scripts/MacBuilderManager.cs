using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class MacBuilderManager : MonoBehaviour
{
    public static MacBuilderManager instance;
    [SerializeField]
    private TypeSnapableObject[] objectsToPlace = new TypeSnapableObject[6];
    [SerializeField]
    private GameObject Fan_Ghost;
    [SerializeField]
    private GameObject HDD_Ghost;
    [SerializeField]
    private GameObject Motherboard_Ghost;
    [SerializeField]
    private GameObject PowerSupply_Ghost;
    [SerializeField]
    private GameObject SpekearLeft_Ghost;
    [SerializeField]
    private GameObject SpekearRight_Ghost;
    [SerializeField]
    private Dictionary<TypeSnapableObject, bool> objectsInPlace = new Dictionary<TypeSnapableObject, bool>();
    //private Dictionary<TypeSnapableObject, bool> retinaDisplayInPlace = new Dictionary<TypeSnapableObject, bool>();
    public bool IsAllInPlace { private get; set; }
    [SerializeField]
    private GameObject RetinaDisplay_ObjectToPlace;
    [SerializeField]
    private GameObject Fan;
    [SerializeField]
    private GameObject HDD;
    [SerializeField]
    private GameObject Motherboard;
    [SerializeField]
    private GameObject PowerSupply;
    [SerializeField]
    private GameObject SpekearLeft;
    [SerializeField]
    private GameObject SpekearRight;
    [SerializeField]
    private GameObject RetinaDisplay;
    [SerializeField]
    private GameObject CableHDD;
    [SerializeField]
    private GameObject CableLogic;
    [SerializeField]
    private GameObject CableRetinaDisplay;
    [SerializeField]
    private ImacFunctions retinaDisplayFunction;

    private bool canPlaceTheRetinaDisplay = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Created singleton");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach(var obj in objectsToPlace)
        {
            objectsInPlace.Add(obj, false);
        }
        RetinaDisplay_ObjectToPlace.SetActive(false);
        //retinaDisplayInPlace.Add(TypeSnapableObject.RetinaDisplay, false);
    }

    public void SetObjectPlacedValue(TypeSnapableObject type, bool _isPlaced)
    {
        Debug.Log("Object in place: " + type);
        if(objectsInPlace.ContainsKey(type))
        {
            objectsInPlace[type] = _isPlaced;
        }
        if(type == TypeSnapableObject.RetinaDisplay)
        {
            IsAllInPlace = true;
            RetinaDisplay_ObjectToPlace.SetActive(false);
            Destroy(RetinaDisplay.GetComponent<Rigidbody>());
            retinaDisplayFunction.TurnOn();
        }
        switch(type)
        {
            case TypeSnapableObject.Fan:
                Fan_Ghost.SetActive(!_isPlaced);
                break;
            case TypeSnapableObject.HDD:
                HDD_Ghost.SetActive(!_isPlaced);
                break;
            case TypeSnapableObject.Motherboard:
                Motherboard_Ghost.SetActive(!_isPlaced);
                break;
            case TypeSnapableObject.PowerSupply:
                PowerSupply_Ghost.SetActive(!_isPlaced);
                break;
            case TypeSnapableObject.SpekearLeft:
                SpekearLeft_Ghost.SetActive(!_isPlaced);
                break;
            case TypeSnapableObject.SpekearRight:
                SpekearRight_Ghost.SetActive(!_isPlaced);
                break;
        }

        if(!Fan_Ghost.activeInHierarchy && !HDD_Ghost.activeInHierarchy && 
            !Motherboard_Ghost.activeInHierarchy && !PowerSupply_Ghost.activeInHierarchy && 
            !SpekearLeft_Ghost.activeInHierarchy && !SpekearRight_Ghost.activeInHierarchy)
        {
            RetinaDisplay_ObjectToPlace.SetActive(true);
            canPlaceTheRetinaDisplay = true;
            PipupModules();
        }
        else
        {
            RetinaDisplay_ObjectToPlace.SetActive(false);
            canPlaceTheRetinaDisplay = false;
        }
    }

    private void PipupModules()
    {
        Destroy(Fan.GetComponent<Rigidbody>());
        Destroy(HDD.GetComponent<Rigidbody>());
        Destroy(Motherboard.GetComponent<Rigidbody>());
        Destroy(PowerSupply.GetComponent<Rigidbody>());
        Destroy(SpekearLeft.GetComponent<Rigidbody>());
        Destroy(SpekearRight.GetComponent<Rigidbody>());
        CableHDD.SetActive(true);
        CableLogic.SetActive(true);
        CableRetinaDisplay.SetActive(true);
    }
}
