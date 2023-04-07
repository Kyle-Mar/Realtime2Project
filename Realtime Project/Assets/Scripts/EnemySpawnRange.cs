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

    public List<List<Vector3>> spawnerColumnList = new List<List<Vector3>>();
    //public List<Vector3> spawnerPositionsList = new List<Vector3>();
    private List<GameObject> spawnersList = new List<GameObject>();

    public bool isActive = true;

    private bool spawnSpawnerBool = true; // tmp for debug




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
            List<Vector3> colList = new List<Vector3>();
            for (float h = spacing / 2.0f; h < height; h += spacing)
            {
                // Not optimal but works I guess...
                switch (transform.rotation.eulerAngles.y)
                {
                    case 0:
                        {
                            colList.Add(new Vector3(corner.transform.position.x - w, corner.transform.position.y - h, corner.transform.position.z + 1.0f));
                            break;
                        }
                    case 90:
                        {
                            colList.Add(new Vector3(corner.transform.position.x + 1.0f, corner.transform.position.y - h, corner.transform.position.z + w));
                            break;
                        }
                    case 180:
                        {
                            colList.Add(new Vector3(corner.transform.position.x + w, corner.transform.position.y - h, corner.transform.position.z - 1.0f));
                            break;
                        }
                    case 270:
                        {
                            colList.Add(new Vector3(corner.transform.position.x - 1.0f, corner.transform.position.y - h, corner.transform.position.z - w));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                spawnerColumnList.Add(colList);
            }
        }
    }

    //void Update()
    //{
    //    waveTimer += Time.deltaTime;

    //    if (waveTimer >= setWaveTimer)
    //    {
    //        // Beginning of New Wave


    //        if (!activeWave)
    //        {
    //            activeWave = true;
    //            UnpauseSpawners();
    //            SpawnSpawners(numToSpawn);
    //            //numToSpawn += 1;
    //        }
    //        else
    //        {
    //            activeWave = false;
    //            PauseSpawners();
    //        }
    //        waveTimer = 0.0f;
            
    //    }

    //}

    public void SpawnSpawners(int numToCreate)
    {
        for (int num = numToCreate; num > 0; num--)
        {
            Debug.Log("SPAWNERS");
            // Create spawner
            int randCol = Random.Range(0, spawnerColumnList.Count-1);
            List<Vector3> spawnerCol = spawnerColumnList[randCol];
            int randSpawner = Random.Range(0, spawnerCol.Count - 1);
            Vector3 spawnerPos = spawnerCol[randSpawner];
            GameObject newSpawner = Instantiate(spawnerPrefab, spawnerPos, transform.rotation);

            // Set enemy to spawn
            int randEnemy = Random.Range(1, 5);
            switch (randEnemy)
            {
                case 1:
                    newSpawner.GetComponent<Spawner>().enemy = blueEnemy;
                    break;
                default:
                    break;
            }

            // Ad to list
            spawnersList.Add(newSpawner);
            spawnerColumnList.Remove(spawnerCol);
    }   }

    public void PauseSpawners()
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

    public void UnpauseSpawners()
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
