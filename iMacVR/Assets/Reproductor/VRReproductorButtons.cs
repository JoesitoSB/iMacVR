using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRReproductorButtons : MonoBehaviour
{
    [SerializeField]
    private ButtonType button;

    [SerializeField]
    private AudioManager aM;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("algo");
        if(other.gameObject.GetComponent<FingerIdentifier>())
        {
            Debug.Log("Dedo");
            switch (button)
            {
                case ButtonType.Play:
                    aM.PararMusica();
                    break;
                case ButtonType.Next:
                    aM.ProximaCancion();
                    break;
                case ButtonType.Prev:
                    aM.CancionAnterior();
                    break;
            }
        }
    }
}
public enum ButtonType
{
    Play,
    Next,
    Prev
}
