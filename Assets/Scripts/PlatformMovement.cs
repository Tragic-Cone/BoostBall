using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove

public class PlatformMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    int speed = 2;
    //Your Update function
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, 5), transform.position.y, transform.position.z);
    }
    
}