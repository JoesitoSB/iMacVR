using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductoPunto : MonoBehaviour
{

    public Transform other;
    public bool InFront;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {

            Vector3 foraward2 = transform.TransformDirection(Vector3.up);
            Vector3 toOther2 = other.position - transform.position;

            Vector3 foraward3 = transform.TransformDirection(Vector3.right);
            Vector3 toOther3 = other.position - transform.position;
            //Debug.Log(foraward);
            Debug.Log("y: " + Vector3.Dot(foraward2, toOther2));
            Debug.Log("z: " + Vector3.Dot(foraward3, toOther3));
            if (Vector3.Dot(foraward2, toOther2) < 0.05f && Vector3.Dot(foraward2, toOther2) > -0.05f)
            {
                if (Vector3.Dot(foraward3, toOther3) < 0.05f && Vector3.Dot(foraward3, toOther3) > -0.05f)
                {
                    Debug.Log("is almost perfect");
                    InFront = true;
                }
                else
                {
                    InFront = false;
                }
                
            }
        }
    }
}
