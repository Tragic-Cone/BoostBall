using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class CollisionDelete : MonoBehaviour
{
    [SerializeField] ObjectCollector objCollector;
    private float IFrames;
    public AudioClip hitSound;
    public AudioClip deadSound;

    private void Start()
    {
        objCollector = this.GetComponent<ObjectCollector>();
    }
    private void Update()
    {
        if(IFrames > 0)
        {
            Debug.Log(IFrames);
            IFrames = IFrames - Time.deltaTime * 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && IFrames <= 0)
        {
            
            if(objCollector.getNumShields()>0)
            {
                IFrames = 2;
                objCollector.harmPlayer();
                Destroy(collision.gameObject);
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }
            else
            {
                this.gameObject.active = false;
                AudioSource.PlayClipAtPoint(deadSound, transform.position);
            }
            
            //Destroys object that this script is attached to

        }
        else if(collision.gameObject.tag == "void")
        {
            this.gameObject.active = false;
            AudioSource.PlayClipAtPoint(deadSound, transform.position);
        }
        if (collision.gameObject.tag == "start boost")
        {
            Destroy(collision.GetComponent<Collider>().gameObject);
        }
    }
}
