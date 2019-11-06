using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Magnets : MonoBehaviour
{
    public GameObject[] MagnetScrew;
    
    public bool attached = false;
    private float[] Distance;
    public float SnapScrewDistance;
    [SerializeField]
    public GameObject NearGameObject = null;
    private Vector3 fromVector;
    private Vector3 toVector;
    public float speed = 0.1f;
    private float Dist = 0;


    // Start is called before the first frame update
    void Start()
    {
        MagnetScrew = GameObject.FindGameObjectsWithTag("Screw");
        Distance = new float[MagnetScrew.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (!attached)
        {
            NearGameObject = GetTipNearest(MagnetScrew);
        }
        
        Dist = Vector3.Distance(NearGameObject.transform.position, transform.position);
        //Debug.Log(Dist);
        //Debug.Log(attached);
        if (Dist <= SnapScrewDistance)
        {
            if (!attached && !NearGameObject.GetComponent<Tip>().Screw)
            {
                NearGameObject.transform.position = transform.position;
                NearGameObject.transform.parent = transform;
                NearGameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                
                toVector = new Vector3(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y,
                    transform.parent.localEulerAngles.z);
                //toVector -= new Vector3(180, 0, 0);
                fromVector = NearGameObject.transform.eulerAngles;
                //Debug.Log("to: " + toVector);
                //Debug.Log("from: " + fromVector);

                //NearGameObject

                fromVector = new Vector3(
                    Mathf.LerpAngle(fromVector.x, toVector.x, Time.deltaTime * speed),
                    Mathf.LerpAngle(fromVector.y, toVector.y, Time.deltaTime * speed),
                    Mathf.LerpAngle(fromVector.z, toVector.z, Time.deltaTime * speed));
                NearGameObject.transform.eulerAngles = fromVector;

                if (fromVector.x < toVector.x + 0.09f && fromVector.x > toVector.x - 0.09f &&
                    fromVector.y < toVector.y + 0.09f && fromVector.y > toVector.y - 0.09f &&
                    fromVector.z < toVector.z + 0.09f && fromVector.z > toVector.z - 0.09f)
                {
                    attached = true;
                }

                
            }

            //if (attached)
            //{
            //    NearGameObject.transform.position = transform.position;
            //}
        }
        else if(Dist > SnapScrewDistance && attached)
        {
            NearGameObject.transform.parent = null;
            NearGameObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            attached = false;
        }

        //quitar este if despues
        //if (transform.parent.gameObject.GetComponent<DragAndDrop>().dragging)
        //{
        //    transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
        //}
        //else
        //{
        //    transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //}
    }

    private GameObject GetTipNearest(GameObject[] magnets)
    {
        float NearDistance = 0;
        float ActualDistance = 0;
        GameObject NearObject = null;
        for (int i = 0; i < magnets.Length; i++)
        {
            ActualDistance = Vector3.Distance(magnets[i].transform.position, transform.position);
            if (i == 0)
            {
                NearObject = magnets[i];
                NearDistance = ActualDistance;
            }
            
            
            if (ActualDistance < NearDistance)
            {
                NearObject = magnets[i];
                NearDistance = ActualDistance;
            }
            //Debug.Log(NearObject);
            
        }

        return NearObject;
    }
}
