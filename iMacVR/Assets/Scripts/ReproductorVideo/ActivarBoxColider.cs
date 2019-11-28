using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBoxColider : MonoBehaviour
{
    public BoxCollider BotonBoxColider;
    public float Tiempo;
    private float NewTime;

    private void Awake()
    {
        NewTime = Tiempo;
    }
}
