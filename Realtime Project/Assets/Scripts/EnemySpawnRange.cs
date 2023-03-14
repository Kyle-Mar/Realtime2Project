using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRange : MonoBehaviour
{
    public GameObject corner;
    public GameObject enemy;
    public GameObject spawnerPrefab;
    private float width;
    private float height;
    private float spacing = 4.0f;
    public List<Vector3> spawnerList = new List<Vector3>();

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
            for (float h = spacing / 2.0f; h < height; h += spacing)
            {
                // Not optimal but works I guess...
                switch(transform.rotation.eulerAngles.y)
                {
                    case 0:
                    {
                        spawnerList.Add(new Vector3(corner.transform.position.x - w, corner.transform.position.y - h, corner.transform.position.z + 1.0f));
                        break;
                    }
                    case 90:
                    {
                        spawnerList.Add(new Vector3(corner.transform.position.x + 1.0f, corner.transform.position.y - h, corner.transform.position.z + w));
                        break;
                    }
                    case 180:
                    {
                        spawnerList.Add(new Vector3(corner.transform.position.x + w, corner.transform.position.y - h, corner.transform.position.z - 1.0f));
                        break;
                    }
                    case 270:
                    {
                        spawnerList.Add(new Vector3(corner.transform.position.x - 1.0f, corner.transform.position.y - h, corner.transform.position.z - w));
                        break;
                    }
    }   }   }   }

    void Update()
    {
        if (spawnSpawnerBool)
        {
            SpawnSpawners(3);
            spawnSpawnerBool=false;
    }   }

    void SpawnSpawners(int numToCreate)
    {
        for (int num = numToCreate; num > 0; num--)
        {
            int rand = Random.Range(0, spawnerList.Count-1);
            Vector3 spawnerPos = spawnerList[rand];
            GameObject newSpawner = Instantiate(spawnerPrefab, spawnerPos, transform.rotation);
            spawnerList.Remove(spawnerPos);
    }   }
}
