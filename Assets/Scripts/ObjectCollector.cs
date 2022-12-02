using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private int coin = 0;
    private int shield = 0;
    public TextMeshProUGUI textcoins;
    public TextMeshProUGUI textshield;
    public AudioClip coinSound;
    public AudioClip shieldSound;
    public AudioClip bounceSound;

    [SerializeField] shieldState shieldState;

    private void Update()
    {
        shieldState.numShields = shield;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
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
                shield = 3;
            }
            textshield.text = "X" + shield;
            Destroy(other.gameObject);
            

        }
    }

    public int getNumShields()
    {
        return shield;
    }

    public void harmPlayer()
    {
        shield--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            AudioSource.PlayClipAtPoint(bounceSound, transform.position);
        }
    }
}
