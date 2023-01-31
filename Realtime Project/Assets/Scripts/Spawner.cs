using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public float spawnCooldown= 1f;
    private float lastSpawnTime = 0f;

    private Vector3 spawnLocation;
    private Quaternion spawnRotation;

    private void Start()
    {
        // look for the necessary stuff here
        spawnLocation = gameObject.transform.Find("SpawnLocation").transform.position;
        spawnRotation = Quaternion.Euler(0f, gameObject.transform.eulerAngles.y, 0f);
    }

    void Update()
    {
        if (lastSpawnTime + spawnCooldown < Time.time)
        {
            SpawnAnEnemy();
            lastSpawnTime= Time.time;
        }
    }

    void SpawnAnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy, spawnLocation, spawnRotation);
        // get new enemy's enemy ai Script and set the values of player and control panel.
    }
}
