using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Vector3 offset;
    public float x, y, z;
    // Update is called once per frame
    private void Start()
    {
        offset = transform.position - target.position;

    }
    void Update()
    {
        transform.position = new Vector3(0 + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        /*transform.position = target.transform.position + new Vector3(x, y, z);
        transform.LookAt(target.transform.position);*/
    }
}
