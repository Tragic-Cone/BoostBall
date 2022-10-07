using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class shieldState : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //References placed in editor
    [SerializeField] Sprite[] spriteArray;
    //SerializeFielded for debug purposes
    [SerializeField] int numShields;

    //Pulse Renderer
    [SerializeField] SpriteRenderer shieldPulse;

    //Gameobject to hold shield particle renderer
    [SerializeField]GameObject particleObject;
    [SerializeField]ParticleSystem particleSystem;

    //Gradient Colors
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;

    //particle attributes
    ParticleSystem.MainModule main;
    ParticleSystem.ShapeModule shape;
    ParticleSystem.EmissionModule emission;

    // Start is called before the first frame update
    void Start()
    {
        //fetching sprite renderer from object
        spriteRenderer = GetComponent<SpriteRenderer>();
        //initializing numShields
        numShields = 0;
        //Pulling particleSystem from particleObject
        particleSystem = particleObject.GetComponent<ParticleSystem>();
        main = particleSystem.main;
        shape = particleSystem.shape;
        emission = particleSystem.emission;

        //Setting Colors
        color1 = new Color(0.6f, 0.89804f, 0.31373f);
        color2 = new Color(0.98431f, 0.94902f, 0.21176f);
        color3 = new Color(0.87451f, 0.44314f, 0.14902f);


    }

    // Update is called once per frame
    void Update()
    {
        //changing shield sprite beign rendered based on numShields
        spriteRenderer.sprite = spriteArray[numShields];

        //preventing shields from overflowing past values with which sprites exist
        if(numShields > 3)
        {
            numShields = 3;
        }

        //Disabling shield object whenever the player has no shield
        if(numShields == 0)
        {
            shieldPulse.enabled = false;
            particleObject.SetActive(false);
        }
        else
        {
            shieldPulse.enabled = true;
            particleObject.SetActive(true);
        }

        //Handling particle system intensity based on shield state
        switch (numShields)
        {
            case 1:
                //var main0 = particleSystem.main;
                main.startColor = color1;
                main.startSpeed = -1.75f;
                emission.rateOverTime = 10f;
                //var shape0 = particleSystem.shape;
                shape.radius = 1.5f;
                break;

            case 2:
                //var main1 = particleSystem.main;
                main.startColor = color2;
                main.startSpeed = -2f;
                emission.rateOverTime = 16f;
                //var shape1 = particleSystem.shape;
                shape.radius = 1.75f;
                break;

            case 3:
                //var main2 = particleSystem.main;
                main.startColor = color3;
                main.startSpeed = -2.5f;
                emission.rateOverTime = 27f;
                //var shape2 = particleSystem.shape;
                shape.radius = 2f;
                break;
        }

    }
}
