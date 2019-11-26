using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class WireBroke : MonoBehaviour
{
    public ObiRope rope;
    //public GameObject tethersGameObject;
    public ObiTetherConstraints tether;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rope.pooledParticles < 10)
        {
            tether.enabled = false;
            //tethersGameObject.SetActive(false);
        }
        
    }
}
