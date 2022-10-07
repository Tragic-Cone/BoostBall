using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private int health;
    private bool hasShield;
    private int numCoins;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        hasShield = false;
        numCoins = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
