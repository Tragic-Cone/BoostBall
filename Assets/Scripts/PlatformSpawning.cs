using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawning: MonoBehaviour
{
    public GameObject platformPrefab1;
    public GameObject platformPrefab2;
    public GameObject platformPrefab3;

    public int platformCount = 3;
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        float xPosition = Random.Range(-5f, 5f);
        float yPosition = 5f;

        for (int i = 0; i < platformCount; i++)
        {
             int pnum = Random.Range(1, 4);
             if (pnum == 1)
             {
                 spawnPosition.y += yPosition;
                 spawnPosition.x = xPosition;
                 Instantiate(platformPrefab1, spawnPosition, Quaternion.identity);
             }
             else if (pnum == 2)
             {
                 spawnPosition.y += yPosition;
                 spawnPosition.x = xPosition;
                 Instantiate(platformPrefab2, spawnPosition, Quaternion.identity);
             }
             else if (pnum == 3)
             {
                 spawnPosition.y += yPosition;
                 spawnPosition.x = xPosition;
                 Instantiate(platformPrefab3, spawnPosition, Quaternion.identity);
             }
        }

    }

}
