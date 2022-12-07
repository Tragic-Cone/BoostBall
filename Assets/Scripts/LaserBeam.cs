using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class LaserBeam : MonoBehaviour
{
    private PolygonCollider2D lbCollider;
    public float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        lbCollider = GetComponent<PolygonCollider2D>();
        lbCollider.enabled = !lbCollider.enabled;
    }

    // Update is called once per frame
    void Update()
    {


        currentTime += Time.deltaTime;
        if (currentTime >= 1.2f && currentTime <= 1.45f)
        {
            lbCollider.enabled = true;
            
        }
        else if(currentTime >= 1.45f)
        {
            lbCollider.enabled = false;
        }
        else
        {
            lbCollider.enabled = false;
        }
        if(currentTime >= 2.67f)
        {
            currentTime = 0;
        }


    }
}
