using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    // Start is called before the first frame update
    private float coin = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.transform.tag == "Ball")
        {
            Destroy(this.gameObject);
        }
        if (other.transform.tag == "Noncoins")
        {
            Destroy(this.gameObject);
        }
    }
    
}
