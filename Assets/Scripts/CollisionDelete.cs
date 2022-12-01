using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class CollisionDelete : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "void")
        {
            //Destroys object that this script is attached to
            Destroy(this.gameObject);

        }
        if (collision.gameObject.tag == "start boost")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
