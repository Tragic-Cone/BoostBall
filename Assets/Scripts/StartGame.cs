using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject UIObject;
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject PlaceholderBall;
    public void clickedStart()
    {
        UIObject.SetActive(false);
        Ball.SetActive(true);
        PlaceholderBall.SetActive(false);
    }
}
