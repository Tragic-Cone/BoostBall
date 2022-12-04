using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore{
    public string username {get; set;}
    public int highScore {get; set;}

    public PlayerScore(string username, int highScore){
        this.username = username;
        this.highScore = highScore;
    }
}