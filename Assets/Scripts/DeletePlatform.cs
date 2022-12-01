using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlatform : MonoBehaviour
{
    private GameObject MainCamera;
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
     void Update()
     {
         if (transform.position.y <= -10.5f + MainCamera.GetComponent<Transform>().position.y)
         {
            Destroy(this.gameObject);
         }

     }
    
   
    
}
