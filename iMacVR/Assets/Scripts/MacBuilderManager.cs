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
    }
}
