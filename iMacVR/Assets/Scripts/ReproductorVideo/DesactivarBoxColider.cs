using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarBoxColider : MonoBehaviour
{
    public BoxCollider BotonBoxColider;

    public void DesactivarBox(BoxCollider _BoxColider)
    {
        _BoxColider.enabled = false;
    }

    public void OnDisable()
    {
        BotonBoxColider.enabled = true;
    }

}
