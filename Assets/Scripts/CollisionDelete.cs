using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDelete : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //Destroys object that this script is attached to
            Destroy(this.gameObject);

        }
    }
}
