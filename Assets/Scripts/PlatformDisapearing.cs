using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class PlatformDisapearing : MonoBehaviour
{

    public float timeToToggle = 1.25f;
    public float currentTime = 0;
    public bool pEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        pEnabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToToggle)
        {
            currentTime = 0;
            TogglePlatform();
            if(currentTime >= .5f)
            {
                currentTime = 0;
                TogglePlatform();
            }
        }
    }

    void TogglePlatform()
    {
        pEnabled = !pEnabled;
        foreach(Transform child in gameObject.transform)
        {
            if(child.name == "Middle")
            {
                child.gameObject.SetActive(pEnabled);
            }
        }
    }
}
