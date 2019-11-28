using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDespuesDe : MonoBehaviour
{
    public BoxCollider ThisCol;
    public float Tiempo;
    private float _Time;

    private void Start()
    {
        _Time = Tiempo;
        ThisCol.enabled = false;
    }

    void Update()
    {
        _Time -= Time.deltaTime;
        if(_Time < 0)
        {
            ThisCol.enabled = true;
        }
    }
}
