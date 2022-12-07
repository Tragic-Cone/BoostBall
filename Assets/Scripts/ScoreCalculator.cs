using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    //score = 1000 x coins, 10 x distance
    [SerializeField] ObjectCollector coins;
    [SerializeField] Camera distance;
    private int score;
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)(distance.transform.position.y*10) + (coins.getCoins() * 1000);
        tmp.text = "" + score;
    }
    public int getScore(){
        return score;
    }
}
