using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawning : MonoBehaviour
{
    public GameObject platformPrefab1;
    public GameObject platformPrefab2;
    public GameObject platformPrefab3;

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
        GameObject[] GameobjectList = GameObject.FindGameObjectsWithTag("platform");

        Vector3 spawnPosition = new Vector3();


        currentTime += Time.deltaTime;

        if (GameobjectList.Length < 3 && currentTime >= timeToSpawn)
        {

            float maxY = GameobjectList[0].GetComponent<Transform>().position.y;
            for(int i = 0; i < GameobjectList.Length; i++)
            {
                if(GameobjectList[i].GetComponent<Transform>().position.y > maxY)
                {
                    maxY = GameobjectList[i].GetComponent<Transform>().position.y;
                }
            }
            float xPosition = Random.Range(-5f, 5f);
            float yPosition = 10f + maxY;
            currentTime = 0;

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
    