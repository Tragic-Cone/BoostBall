using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D rigid;
    public float smoothTime = 0.3f;
    Vector2 currentVelocity;

    private void Start()
    {
        //rigid = GetComponent<Rigidbody>();
        
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        /*if (Input.GetAxis("Horizontal") > 0)
        {
            rigid.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.AddForce(-Vector3.right * speed);
        }*/
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(transform.position.x, mousePosition, ref currentVelocity, smoothTime, speed);


    }
}
