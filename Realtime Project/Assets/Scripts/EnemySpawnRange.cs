using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRange : MonoBehaviour
{
    public GameObject corner;
    public GameObject enemy;
    public GameObject blueEnemy;
    public GameObject spawnerPrefab;
    private float width;
    private float height;
    private float spacing = 4.0f;

    public int numToSpawn = 1;
    public List<Vector3> spawnerPositionsList = new List<Vector3>();
    private List<GameObject> spawnersList = new List<GameObject>();

    public bool isActive = true;
    private bool activeWave = false;

    private bool spawnSpawnerBool = true; // tmp for debug

    // Debug Wave System
    public float waveTimer = 0.0f;
    private float setWaveTimer = 10.0f;
    

    void Start()
    {
        // Set Corner Location
        width = transform.localScale.x;
        height = transform.localScale.y;
        corner.transform.localPosition = new Vector3(0.5f, 0.5f, 0.0f);

        // Set List of Spawners
        // Add first then remove method
        // Should change to blank first then add method
        for (float w = spacing / 2.0f; w < width; w += spacing)
        {
            for (float h = spacing / 2.0f; h < height; h += spacing)
            {
                // Not optimal but works I guess...
                switch(transform.rotation.eulerAngles.y)
                {
                    case 0:
                    {
                        spawnerPositionsList.Add(new Vector3(corner.transform.position.x - w, corner.transform.position.y - h, corner.transform.position.z + 1.0f));
                        break;
                    }
                    case 90:
                    {
                        spawnerPositionsList.Add(new Vector3(corner.transform.position.x + 1.0f, corner.transform.position.y - h, corner.transform.position.z + w));
                        break;
                    }
                    case 180:
                    {
                        spawnerPositionsList.Add(new Vector3(corner.transform.position.x + w, corner.transform.position.y - h, corner.transform.position.z - 1.0f));
                        break;
                    }
                    case 270:
                    {
                        spawnerPositionsList.Add(new Vector3(corner.transform.position.x - 1.0f, corner.transform.position.y - h, corner.transform.position.z - w));
                        break;
                    }
    }   }   }   }

    void Update()
    {
        waveTimer += Time.deltaTime;
        if (waveTimer >= setWaveTimer)
        {
            if (!activeWave)
            {
                activeWave = true;
                UnpauseSpawners();
                SpawnSpawners(numToSpawn);
                //numToSpawn += 1;
                waveTimer = 0.0f;
            }
            else
            {
                activeWave = false;
                PauseSpawners();
                waveTimer = 0.0f;
            }
            
        }

    }

    void SpawnSpawners(int numToCreate)
    {
        for (int num = numToCreate; num > 0; num--)
        {
            // Create spawner
            int rand = Random.Range(0, spawnerPositionsList.Count-1);
            Vector3 spawnerPos = spawnerPositionsList[rand];
            GameObject newSpawner = Instantiate(spawnerPrefab, spawnerPos, transform.rotation);

            // Set enemy to spawn
            rand = Random.Range(1, 5);
            switch (rand)
            {
                case 1:
                    newSpawner.GetComponent<Spawner>().enemy = blueEnemy;
                    break;
            }

            // Ad to list
            spawnersList.Add(newSpawner);
            spawnerPositionsList.Remove(spawnerPos);
    }   }

    void PauseSpawners()
    {
        if (isActive)
        {
            foreach (GameObject spawner in spawnersList)
            {
                spawner.GetComponent<Spawner>().isActive = false;
            }
            isActive = false;
        }
    }

    void UnpauseSpawners()
    {
        if (!isActive)
        {
            foreach (GameObject spawner in spawnersList)
            {
                spawner.GetComponent<Spawner>().isActive = true;
            }
        }
        isActive = true;
    }
}
