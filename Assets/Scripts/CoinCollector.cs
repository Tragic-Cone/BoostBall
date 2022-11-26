using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
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
           textcoins.text = "" + coin;
            Destroy(other.gameObject);
            //textcoins.text = string(coin);

        }
            if (other.transform.tag == "Ball")
        {

        }
        if (other.transform.tag == "Platform&shields")
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
 
    // Start is called before the first frame update

}
