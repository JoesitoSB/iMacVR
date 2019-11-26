using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 1. 8-directional movement
/// 2.true stop and face current direction when input is absent
public class PlayerController : MonoBehaviour
{
    //---------------------------
    public float velocity = 6;
    public float turnSpeed = 10;
    Vector2 JoystickInput;
    float angle;
    Quaternion targetRotation;
    Transform cam;

    void Start() 
    {
        cam = Camera.main.transform;   
    }
    void Update() 
    {
            GetMovementInput();

            if(JoystickInput.x ==  0 && JoystickInput.y ==  0) return;
            
            CalculateDirection();
            Rotate();
            Move();  
    }
    void GetMovementInput() //Input based on Horizontal and Vertical keys)
    {
        JoystickInput.x = Input.GetAxisRaw("Horizontal");
        JoystickInput.y = Input.GetAxisRaw("Vertical");      
    }
    void CalculateDirection() //Direction realtive to the cameras rotation
    {
        angle = Mathf.Atan2(JoystickInput.x, JoystickInput.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }
    void Rotate() //Rotate toward the calculated angle
    {
        targetRotation = Quaternion.Euler(0,angle,0);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,turnSpeed*Time.deltaTime);
    }
    void Move() // This player only moves along its own foward axis
    {
        float AxisNormalized = Mathf.Abs(JoystickInput.x) + Mathf.Abs(JoystickInput.y);
        
        float newVelocity = Mathf.Abs(velocity * AxisNormalized);
        transform.position += transform.forward * newVelocity * Time.deltaTime;
    }

}

