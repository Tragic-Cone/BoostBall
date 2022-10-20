using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    int speed = 2;
    //Your Update function
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, 10), transform.position.y, transform.position.z);
    }
    
}