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
    public AudioClip coinSound;
    public AudioClip shieldSound;
    public AudioClip bounceSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "platform")
        {
            AudioSource.PlayClipAtPoint(bounceSound, transform.position);
        }
        if (other.transform.tag == "coin")
        {
            coin++;
            textcoins.text = "X" + coin;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(other.gameObject);
            //textcoins.text = string(coin);

        }
        
        if (other.transform.tag == "shield")
        {
            shield++;
            AudioSource.PlayClipAtPoint(shieldSound, transform.position);
            if (shield > 3)
            {
                shield--;
            }
            textshield.text = "X" + shield;
            Destroy(other.gameObject);

        }
    }
}
