using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnImac : MonoBehaviour
{

    [SerializeField] MeshRenderer mR;
    [SerializeField] GameObject RetinaOn;
    [SerializeField] GameObject canvas;
    public void Start()
    {
        TurnOff();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            TurnOn();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            TurnOff();
        }
    }
    public void TurnOff()
    {
        mR.enabled = false;
        RetinaOn.SetActive(true);
        canvas.SetActive(false);
    }
    public void TurnOn()
    {
        StartCoroutine("TurnOnC");
    }
    public IEnumerator TurnOnC()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(4);
        canvas.SetActive(false);
        RetinaOn.SetActive(true);
    }
}
