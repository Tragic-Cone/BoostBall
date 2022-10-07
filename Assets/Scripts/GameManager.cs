using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;

    public int platformCount = 3;
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            if (i == 0)
            {
                spawnPosition.y = GameObject.Find("Platfrom").transform.position.y + 10f;
                spawnPosition.x = Random.Range(-10f, 10f);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                spawnPosition.y += 10f;
                spawnPosition.x = Random.Range(-5f, 5f);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }

        }
        
    }

}
