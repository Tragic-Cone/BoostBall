using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenBallFallsHolographic : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D ballRigidbody;
    private BoxCollider2D[] boxColliders;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        boxColliders = GetComponentsInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballRigidbody.velocity.y > 0)
        {
            for(int i = 0; i < boxColliders.Length; i++)
            {
                boxColliders[i].isTrigger = true;
            }
        }
        else
        {
            for (int i = 0; i < boxColliders.Length; i++)
            {
                boxColliders[i].isTrigger = false;
            }
        }
    }

}
