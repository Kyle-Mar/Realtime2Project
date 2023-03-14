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

    public bool isActive = true;

    GameObject player;
    GameObject controlPanel;

    private void Start()
    {
        controlPanel = GameObject.Find("Center Console");
        player = GameObject.Find("Player");

        if(controlPanel == null || player == null)
        {
            Debug.LogError("Unresolved reference in Spawner.cs");
        }


        spawnLocation = gameObject.transform.Find("SpawnLocation").transform.position;
        spawnRotation = Quaternion.Euler(0f, gameObject.transform.eulerAngles.y, 0f);
    }

    void Update()
    {
        if (lastSpawnTime + spawnCooldown < Time.time && isActive)
        {
            SpawnAnEnemy();
            lastSpawnTime= Time.time;
        }
    }

    void SpawnAnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy, spawnLocation, spawnRotation);
        EnemyAI script = newEnemy.GetComponent<EnemyAI>();
        script.player = player;
        script.controlPanel = controlPanel;
    }
}
