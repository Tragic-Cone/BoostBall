using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = transform.position;
        //move.y = 0;
        GameObject ball = GameObject.Find("Ball");
        if (ball.transform.position.y > 0) 
        {
            offset = ball.transform.position.y;
            ball.transform.position = new Vector2(ball.transform.position.x, 0);
        }
        transform.position =  new Vector2(transform.position.x, transform.position.y - offset);
    }
}
