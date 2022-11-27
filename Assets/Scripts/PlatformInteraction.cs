using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformInteraction : MonoBehaviour
{
    public GameObject platform;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private int distance = 1;
    // Use this for initialization
    public void Start()
    {
        StartCoroutine(platformWave());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void spawnPlatform()
    {
        
        int pnum = Random.Range(1, 4);
        int pnum2 = Random.Range(1, 4);
        /*List<int> pointsA = new List<int>();
        List<int> pointsB = new List<int>();
        pointsA.Add(pnum);
        pointsB.Add(pnum2);*/        
        GameObject a = Instantiate(platform) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x + pnum, screenBounds.x + pnum2), screenBounds.y);
        screenBounds.y = screenBounds.y + 10;
    }
    IEnumerator platformWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPlatform();
        }
    }
}