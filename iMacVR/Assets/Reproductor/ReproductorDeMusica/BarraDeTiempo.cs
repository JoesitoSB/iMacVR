using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeTiempo : MonoBehaviour
{
    public Image TimeBar;
    public float maxTime;
    float TimeLeft;
    public bool IsPlaying;

    void Start()
    {
        TimeBar = GetComponent<Image>();
        TimeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        TimeBar.fillAmount = TimeLeft / maxTime;

        if (IsPlaying)
        {
           
        }
    }   
}
