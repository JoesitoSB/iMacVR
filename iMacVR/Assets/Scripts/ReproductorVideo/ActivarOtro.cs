using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarOtro : MonoBehaviour
{
    public void Activar(GameObject otro)
    {
        otro.gameObject.SetActive(true);
    }
}
