using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImacFunctions : MonoBehaviour
{

    [SerializeField] MeshRenderer mR;
    [SerializeField] GameObject turnOn;
    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        TurnOff();
    }

    // Update is called once per frame
    void Update()
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

    public void TurnOn()
    {
        StartCoroutine("TurnOnC");
    }
    public void TurnOff()
    {
        mR.enabled = true;
        turnOn.SetActive(false);
        canvas.SetActive(false);
    }
    public IEnumerator TurnOnC()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(4);
        mR.enabled = false;
        canvas.SetActive(false);
        turnOn.SetActive(true);
    }
}
