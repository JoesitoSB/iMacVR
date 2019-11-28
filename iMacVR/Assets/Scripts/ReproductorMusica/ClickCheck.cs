using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCheck : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fingure")
        {
            Debug.LogError("SE TOCO ALGO EN EL IPAD");
            this.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
