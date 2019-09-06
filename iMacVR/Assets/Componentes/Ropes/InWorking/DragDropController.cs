using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class DragDropController : MonoBehaviour
{
    public GameObject ropeStart;
    public GameObject ropeEnd;

    private Rigidbody ropeStartRigidbody;
    private Rigidbody ropeEndRigidbody;
    private ObiRigidbody ropeStartObiRigidbody;
    private ObiRigidbody ropeEndObiRigidbody;

    private bool ropeStartHolding;
    private bool ropeEndHolding;

    // Start is called before the first frame update
    void Start()
    {
        ropeStartObiRigidbody = ropeStart.GetComponent<ObiRigidbody>();
        ropeEndObiRigidbody = ropeEnd.GetComponent<ObiRigidbody>();
        ropeEndRigidbody = ropeEnd.GetComponent<Rigidbody>();
        ropeStartRigidbody = ropeStart.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ropeStartHolding = ropeStart.GetComponent<DragDrop>().holding;
        ropeEndHolding = ropeEnd.GetComponent<DragDrop>().holding;

        if (ropeStartHolding && !ropeEndHolding)
        {
            ropeStartRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            ropeEndRigidbody.constraints = RigidbodyConstraints.None;
            ropeStartObiRigidbody.kinematicForParticles = true;
            ropeEndObiRigidbody.kinematicForParticles = false;
        }
        else if (!ropeStartHolding && ropeEndHolding)
        {
            ropeEndRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            ropeStartRigidbody.constraints = RigidbodyConstraints.None;
            ropeEndObiRigidbody.kinematicForParticles = true;
            ropeStartObiRigidbody.kinematicForParticles = false;
        }
        else if(ropeStartHolding && ropeEndHolding)
        {
            ropeStartRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            ropeEndRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            ropeStartObiRigidbody.kinematicForParticles = true;
            ropeEndObiRigidbody.kinematicForParticles = true;
        }
        else if(!ropeStartHolding && !ropeEndHolding)
        {
            ropeStartRigidbody.constraints = RigidbodyConstraints.None;
            ropeEndRigidbody.constraints = RigidbodyConstraints.None;
            ropeStartObiRigidbody.kinematicForParticles = false;
            ropeEndObiRigidbody.kinematicForParticles = false;
        }
    }
}
