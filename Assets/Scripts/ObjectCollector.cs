using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private float coin = 0;
    private float shield = 0;
    public TextMeshProUGUI textcoins;
    public TextMeshProUGUI textshield;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Coin")
        {
            coin++;
            textcoins.text = "X" + coin;
            Destroy(other.gameObject);
            //textcoins.text = string(coin);

        }
        if (other.transform.tag == "Ball")
        {

        }
        if (other.transform.tag == "shield")
        {
            shield++;
            if (shield > 3)
            {
                shield--;
            }

            textshield.text = "X" + shield;
            Destroy(other.gameObject);

        }
    }
}
