using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRange : MonoBehaviour
{
    public GameObject enemySpawner;

    private float width;
    private float height;
    private float spawnLimit;
    private List<GameObject> spawnList;

    // Timer
    private float timerSet = 4.0f;
    private float timer = 0.0f;

    void Start()
    {
        width = transform.localScale.x / 4.0f;
        height = transform.localScale.y / 4.0f;
        spawnLimit = width * height;
    }

    void Update()
    {
        if (timer <= 0.0f)
        {
            timer = timerSet;

            bool openSpot = false;
            Vector3 spawnPos = Vector3.zero;
            
            if (spawnList.Count < spawnLimit)
            {
                while (!openSpot)
                {
                    spawnPos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0.0f);
                    spawnPos -= new Vector3(width / 2.0f, height / 2.0f, 0.0f);

                }
            }
            
            
            GameObject newSpawner = Instantiate(enemySpawner, spawnPos, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            spawnList.Add(newSpawner);
        }
    }
}
