using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDelete : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys object that this script is attached to
        Destroy(this.gameObject);
    }

}
