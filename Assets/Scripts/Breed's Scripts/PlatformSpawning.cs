using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawning : MonoBehaviour
{
    public GameObject platformPrefab1;
    public GameObject platformPrefab2;
    public GameObject platformPrefab3;
    public GameObject platformPrefab4;
    public GameObject platformPrefab5;
    public GameObject platformPrefab6;

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
        float xPosition = Random.Range(-5f, 5f);
        float yPosition = 10f + MainCamera.GetComponent<Transform>().position.y;

        currentTime += Time.deltaTime;

        if (GameobjectList.Length < 3 && currentTime >= timeToSpawn)
        {
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
    