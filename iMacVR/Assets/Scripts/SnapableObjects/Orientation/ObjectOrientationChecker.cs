using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class ObjectOrientationChecker : MonoBehaviour
{
    [SerializeField]
    private OrientationId[] OrientationsArray = new OrientationId[3];
    private Dictionary<OrientationId, bool> orientedPoints = new Dictionary<OrientationId, bool>();
    public bool IsOriented { private set; get; }

    private void Start()
    {
        foreach (var orientation in OrientationsArray)
        {
            orientedPoints.Add(orientation, false);
        }
    }

    public void CheckOrientation()
    {
        int correctPoints = 0;
        foreach(var points in orientedPoints)
        {
            if(points.Value)
            {
                correctPoints++;
            }
        }

        //Debug.Log("Screws in position: " + orientedPoints.Count);

        if(correctPoints == orientedPoints.Count)
        {
            IsOriented = true;
        }else
        {
            IsOriented = false;
        }
    }

    public void SetIdentifierValue(OrientationId _orientationId, bool correctPlaced)
    {
        if(orientedPoints.ContainsKey(_orientationId))
        {
            orientedPoints[_orientationId] = correctPlaced;
        }
        CheckOrientation();
    }
}
