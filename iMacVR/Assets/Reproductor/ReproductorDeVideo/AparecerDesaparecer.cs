using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerDesaparecer : MonoBehaviour
{
    public GameObject[] ObjetosDesaparecer;
    public GameObject[] ObjetosAparecer;

    public void Desaparecer()
    {
        for(int i = 0; i < ObjetosDesaparecer.Length; i++)
        {
            ObjetosDesaparecer[i].SetActive(false);
        }
    }

    public void Aparecer()
    {
        for (int i = 0; i < ObjetosAparecer.Length; i++)
        {
            ObjetosAparecer[i].SetActive(true);
        }
    }
}
