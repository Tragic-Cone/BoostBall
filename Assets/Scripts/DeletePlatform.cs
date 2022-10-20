using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlatform : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
     {
         if (transform.position.y <= -6f)
         {
            Destroy(this.gameObject);
         }

     }
    
   
    
}
