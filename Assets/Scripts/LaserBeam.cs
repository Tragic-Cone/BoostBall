using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class LaserBeam : MonoBehaviour
{
    public bool enabled;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<SpriteRenderer>().sprite.name == "beam_12")
        {
            ToggleBeam();
        }
        else if (this.gameObject.GetComponent<SpriteRenderer>().sprite.name == "beam_0")
        {
            ToggleBeam();
        }
    }

    void ToggleBeam()
    {
        enabled = !enabled;
        foreach (Transform gameobject in gameObject.transform)
        {
        
                gameobject.gameObject.SetActive(enabled);
            
        }
    }
}
