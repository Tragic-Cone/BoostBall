using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloAnim : MonoBehaviour
{
    private float timer = 0f;
    Animator animator;

    //Maximum length of timer
    private float maxTime = 10;

    private string currentState = "idle";
    private string state1 = "idle";
    private string state2 = "closing";
    private string state3 = "off";
    private string state4 = "opening";
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
        if (timer > 20)
        {
            timer = 0;
        }

        if (timer > 0 && timer < 5 && currentState != state1)
        {

            animator.Play(state1);
            currentState = state1;
        }
        else if (timer >= 5 && timer <= 15 && currentState != state2)
        {
            animator.Play(state2);
            currentState = state2;
        }
        else if (timer >= 15 && timer <= 20 && currentState != state3)
        {
            animator.Play(state3);
            currentState = state3;
        }
        else
        {
            animator.Play(state4);
            currentState = state4;
        }

    }
}

