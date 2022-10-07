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
    private Transform transform;

    private void Start()
    {
        //rigid = GetComponent<Rigidbody>();
        
        rigid = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
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
        if(Input.GetMouseButton(0))
        {
            transform.position = new Vector3(mousePosition.x, transform.position.y, 0);
        }
    }
}
