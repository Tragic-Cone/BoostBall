using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class LazerBeam : MonoBehaviour
{
    public bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name == "beam_12")
        {
            ToggleBeam();
        }
        else if (this.gameObject.name == "beam_0")
        {
            ToggleBeam();
        }
    }

    void ToggleBeam()
    {
        enabled = !enabled;
        foreach (Transform gameobject in gameObject.transform)
        {
            if (this.gameObject.name == "beam")
            {
                this.gameObject.SetActive(enabled);
            }
        }
    }
}
