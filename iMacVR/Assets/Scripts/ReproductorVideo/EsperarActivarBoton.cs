using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsperarActivarBoton : MonoBehaviour
{
    public BoxCollider Colider;
    public float TiempoDeEspera;
    private float NewTiempodeEspera;

    private void Awake()
    {
        NewTiempodeEspera = TiempoDeEspera;
    }

    private void OnEnable()
    {
        Colider.enabled = false;

        TiempoDeEspera = NewTiempodeEspera;
        while (TiempoDeEspera > 0)
        {
            TiempoDeEspera -= 1 * Time.deltaTime;
        }

        Colider.enabled = true;
    }
}
