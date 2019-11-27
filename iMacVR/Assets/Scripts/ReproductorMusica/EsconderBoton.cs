using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsconderBoton : MonoBehaviour
{
    public GameObject Boton;

    public void Esconder()
    {
        Boton.SetActive(false);
    }

}
