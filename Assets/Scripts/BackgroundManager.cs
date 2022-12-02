using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] public GameObject city3;
    [SerializeField] public GameObject city2;
    [SerializeField] public GameObject city1;
    [SerializeField] public GameObject constant;
    [SerializeField] public Transform transform;
    [SerializeField] public GameObject camera;

    public float distance; 
    // Start is called before the first frame update
    void Start()
    {
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, camera.GetComponent<Transform>().position.y, 10);
        distance = GetComponentInParent<Transform>().position.y;
        if (distance < 19000)
        {
            constant.transform.localPosition = new Vector3(constant.transform.localPosition.x, -(distance / 1000f), constant.transform.localPosition.z);
        }
        city1.transform.localPosition = new Vector3(constant.transform.localPosition.x, -(distance / 100f) + 12 , constant.transform.localPosition.z);
        city2.transform.localPosition = new Vector3(constant.transform.localPosition.x, -(distance / 85f) + 12, constant.transform.localPosition.z);
        city3.transform.localPosition = new Vector3(constant.transform.localPosition.x, -(distance / 70f) + 12, constant.transform.localPosition.z);
    }
}
