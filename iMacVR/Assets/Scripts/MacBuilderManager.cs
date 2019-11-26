﻿using System.Collections;
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

    // Start is called before the first frame update
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach(var obj in objectsToPlace)
        {
            objectsInPlace.Add(obj, false);
        }
    }

    public void SetObjectPlacedValue(TypeSnapableObject type, bool _isPlaced)
    {
        if(objectsInPlace.ContainsKey(type))
        {
            objectsInPlace[type] = _isPlaced;
        }

        switch(type)
        {
            case TypeSnapableObject.Fan:
                Fan_Ghost.SetActive(_isPlaced);
                break;
            case TypeSnapableObject.HDD:
                HDD_Ghost.SetActive(_isPlaced);
                break;
            case TypeSnapableObject.Motherboard:
                Motherboard_Ghost.SetActive(_isPlaced);
                break;
            case TypeSnapableObject.PowerSupply:
                PowerSupply_Ghost.SetActive(_isPlaced);
                break;
            case TypeSnapableObject.SpekearLeft:
                SpekearLeft_Ghost.SetActive(_isPlaced);
                break;
            case TypeSnapableObject.SpekearRight:
                SpekearRight_Ghost.SetActive(_isPlaced);
                break;
        }
    }
}