using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAnim : MonoBehaviour
{
    private float timer = 0f;
    Animator animator;

    //Maximum length of timer
    private float maxTime = 10;

    private string currentState = "circuitidle";
    private string state1 = "circuitidle";
    private string state2 = "circuitpulse";
    //private string state3 = "Animation Name 3";
    // Start is called before the first frame update
    void Start()
    {
        //pulling animator component from the object
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer * 1 * Time.deltaTime;

        //resetting timer
        if (timer > 30)
        {
            timer = 0;
        }

        if (timer > 0 && timer < 29 && currentState != state1)
        {

            animator.Play(state1);
            currentState = state1;
        }
        
        else if (timer >= 29 && timer <= 30 && currentState != state2)
        {
            animator.Play(state2);
            currentState = state2;
        }
        /*
        else
        {
            animator.Play(state3);
            currentState = state3;
        }
        */

    }
}
