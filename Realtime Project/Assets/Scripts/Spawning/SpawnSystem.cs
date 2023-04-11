using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public int numToSpawn = 1;
    public float waveTimer = 0.0f;
    private float setWaveTimer = 10.0f;
    public int waveCount = 0;
    private bool activeWave = false;

    EnemySpawnRange[] children;
    HUD_Text HUD_text_script;

    private void Start()
    {
        children = GetComponentsInChildren<EnemySpawnRange>();
        HUD_text_script = GameObject.Find("HUD").GetComponent<HUD_Text>();
    }


    void Update()
    {
        waveTimer += Time.deltaTime;

        if (waveTimer >= setWaveTimer)
        {

            if (!activeWave)
            {
                // Beginning of New Wave
                waveCount++;
                HUD_text_script.updateWaveCount();

                activeWave = true;
                foreach(EnemySpawnRange child in children)
                {
                    child.UnpauseSpawners();
                    child.SpawnSpawners(numToSpawn);
                }
            }
            else
            {
                activeWave = false;
                foreach(EnemySpawnRange child in children)
                {
                    child.PauseSpawners();
                }
            }
            waveTimer = 0.0f;
        }
    }
}
