using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class ObjectSpawning: MonoBehaviour
{
     public GameObject coinPrefab;
     public int coinCount = 0;

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public int enemyCount = 0;

     void Start()
     {
        int chance = Random.Range(0,10);
        if (chance == 1)
        {
            Vector3 pSpawnPosition = new Vector3();
            float xPosition = Random.Range(-5f, 5f);
            float yPosition = 10f;

            for (int i = 0; i < coinCount; i++)
            {
                pSpawnPosition.y += yPosition;
                pSpawnPosition.x = xPosition;
                Instantiate(coinPrefab, pSpawnPosition, Quaternion.identity);
                coinCount += 1;
            }
        }
        else if (chance == 1 || chance == 5 || chance == 9)
        {
            Vector3 eSpawnPosition = new Vector3();
            float xPosition = Random.Range(-5f, 5f);
            float yPosition = 10f;

            for (int i = 0; i < enemyCount; i++)
            {
                int eNum = Random.Range(1, 3);
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



}
