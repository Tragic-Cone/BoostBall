using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] public GameObject city3;
    [SerializeField] public GameObject city2;
    [SerializeField] public GameObject city1;
    [SerializeField] public GameObject constant;

    public int distance; 
    // Start is called before the first frame update
    void Start()
    {
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (distance < 19000)
        {
            constant.transform.position = new Vector3(constant.transform.position.x, -(distance / 1000f), constant.transform.position.z);
        }
        city1.transform.position = new Vector3(constant.transform.position.x, -(distance / 900f), constant.transform.position.z);
        city2.transform.position = new Vector3(constant.transform.position.x, -(distance / 750f), constant.transform.position.z);
        city3.transform.position = new Vector3(constant.transform.position.x, -(distance / 600f), constant.transform.position.z);
    }
}
