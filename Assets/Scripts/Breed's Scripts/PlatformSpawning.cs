using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawning : MonoBehaviour
{
    public GameObject platformPrefab1;
    public GameObject platformPrefab2;
    public GameObject platformPrefab3;
    public GameObject coinPrefab;
    public GameObject shieldPrefab;
    public GameObject trianglePrefab;
    public GameObject laserPrefab;

    private float timeToSpawn = 1f;
    public float currentTime = 0;

    private GameObject MainCamera;

    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        Vector3 spawnPosition = new Vector3();
        float xPosition = Random.Range(-5f, 5f);
        float yPosition = 10f + MainCamera.GetComponent<Transform>().position.y;

        spawnPosition.y += yPosition;
        spawnPosition.x = xPosition;
        Instantiate(platformPrefab1, spawnPosition, Quaternion.identity);
       
    }

    void Update()
    {
        GameObject[] platformList = GameObject.FindGameObjectsWithTag("platform");
        GameObject[] coinList = GameObject.FindGameObjectsWithTag("coin");
        GameObject[] shieldList = GameObject.FindGameObjectsWithTag("shield");
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("enemy");

        Vector3 spawnPosition = new Vector3();


        currentTime += Time.deltaTime;

        if (platformList.Length < 10)
        {

            float maxY = 0;
            for(int i = 0; i < platformList.Length; i++)
            {
                if(platformList[i].GetComponent<Transform>().position.y > maxY)
                {
                    maxY = platformList[i].GetComponent<Transform>().position.y;
                }
            }
            float xPosition = Random.Range(-5f, 5f);
            float yPosition = 3f + maxY;

            int pnum = Random.Range(1, 11);
            if (pnum == 1 || pnum == 2 || pnum == 3 || pnum == 4 || pnum == 5 || pnum == 6)
            {
                spawnPosition.y = yPosition;
                spawnPosition.x = xPosition;
                Instantiate(platformPrefab1, spawnPosition, Quaternion.identity);
            }
            else if (pnum == 7 || pnum == 8)
            {
                spawnPosition.y = yPosition;
                spawnPosition.x = xPosition;
                Instantiate(platformPrefab2, spawnPosition, Quaternion.identity);
            }
            else if (pnum == 9 || pnum == 10)
            {
                spawnPosition.y = yPosition;
                spawnPosition.x = xPosition;
                Instantiate(platformPrefab3, spawnPosition, Quaternion.identity);
            }
            
        }

        if(coinList.Length < 3)
        {
            float maxY = 0;
            for (int i = 0; i < coinList.Length; i++)
            {
                if (coinList[i].GetComponent<Transform>().position.y > maxY)
                {
                    maxY = coinList[i].GetComponent<Transform>().position.y;
                }
            }
            float xPosition = Random.Range(-5f, 5f);
            float yPosition = 10f + maxY;
            spawnPosition.y += yPosition;
            spawnPosition.x = xPosition;
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }

        if (shieldList.Length < 1)
        {
            float maxY = 0;
            for (int i = 0; i < shieldList.Length; i++)
            {
                if (shieldList[i].GetComponent<Transform>().position.y > maxY)
                {
                    maxY = shieldList[i].GetComponent<Transform>().position.y;
                }
            }
            float xPosition = Random.Range(-5f, 5f);
            float yPosition = 20f + maxY;
            spawnPosition.y += yPosition;
            spawnPosition.x = xPosition;
            Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);
        }

        int numEnemies = 3;
        if(platformList[platformList.Length-1].GetComponent<Transform>().position.y > 500)
        {
            numEnemies = 4;
        }
        else if(platformList[platformList.Length - 1].GetComponent<Transform>().position.y > 1000)
        {
            numEnemies = 5;
        }
        if (enemyList.Length < numEnemies)
        {
            float maxY = 0;
            for (int i = 0; i < enemyList.Length; i++)
            {
                if (enemyList[i].GetComponent<Transform>().position.y > maxY)
                {
                    maxY = enemyList[i].GetComponent<Transform>().position.y;
                }
            }
            float xPosition = Random.Range(-5f, 5f);
            float yPosition = 10f + maxY;
            spawnPosition.y = yPosition;
            spawnPosition.x = xPosition;
            if(Random.Range(0,5) == 0)
            {
                xPosition = Random.Range(3f, 5f);
                spawnPosition.x = xPosition;
                Instantiate(laserPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(trianglePrefab, spawnPosition, Quaternion.identity);
            }
            
        }
    }
}
    