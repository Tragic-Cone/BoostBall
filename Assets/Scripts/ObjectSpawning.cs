using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class ObjectSpawning: MonoBehaviour
{
     public GameObject platformPrefab1;
     public GameObject platformPrefab2;
     public GameObject platformPrefab3;
     public int platformCount = 0;

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public int enemyCount = 0;

     void Start()
     {
         Vector3 pSpawnPosition = new Vector3();
         float xPosition = Random.Range(-5f, 5f);
         float yPosition = 4f;

         for (int i = 0; i < platformCount; i++)
         {
              int pnum = Random.Range(1, 4);
              if (pnum == 1)
              {
                  pSpawnPosition.y += yPosition;
                  pSpawnPosition.x = xPosition;
                  Instantiate(platformPrefab1, pSpawnPosition, Quaternion.identity);
              }
              else if (pnum == 2)
              {
                  pSpawnPosition.y += yPosition;
                  pSpawnPosition.x = xPosition;
                  Instantiate(platformPrefab2, pSpawnPosition, Quaternion.identity);
              }
              else if (pnum == 3)
              {
                  pSpawnPosition.y += yPosition;
                  pSpawnPosition.x = xPosition;
                  Instantiate(platformPrefab3, pSpawnPosition, Quaternion.identity);
              }
         }

        Vector3 eSpawnPosition = new Vector3();
        xPosition = Random.Range(-5f, 5f);
        yPosition = 15f;

        for (int i = 0; i < enemyCount; i++)
        {
            int eNum = Random.Range(1,3);
            if (eNum == 1)
            {
                eSpawnPosition.y += yPosition;
                eSpawnPosition.x += xPosition;
                Instantiate(enemyPrefab1, eSpawnPosition, Quaternion.identity);
            }
            else if (eNum == 2)
            {
                eSpawnPosition.y += yPosition;
                eSpawnPosition.x += xPosition;
                Instantiate(enemyPrefab2, eSpawnPosition, Quaternion.identity);
            }
        }

        
    }



}
