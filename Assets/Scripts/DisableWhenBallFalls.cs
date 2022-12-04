using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenBallFalls : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ballRigidbody.velocity.y > 0)
        {
            boxCollider.isTrigger = true;
        }
        else
        {
            boxCollider.isTrigger = false;
        }
    }
}
