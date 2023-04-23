using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnSystem : MonoBehaviour
{
    public int numToSpawn = 1;
    public float waveTimer = 0.0f;
    private float setWaveTimer = 10.0f;
    public int waveCount = 0;
    private bool activeWave = false;

    EnemySpawnRange[] children;
    GameObject HUD;
    HUD_Text HUD_text_script;
    Image timerImage;
    GameObject waveStartPromptText;

    private void Start()
    {
        children = GetComponentsInChildren<EnemySpawnRange>();
        HUD = GameObject.Find("HUD");
        HUD_text_script = HUD.GetComponent<HUD_Text>();
        timerImage = GameObject.Find("Timer").GetComponent<Image>();
        waveStartPromptText = GameObject.Find("WaveStartPromptText");
        waveStartPromptText.SetActive(false);
        startWave();
    }


    void Update()
    {
        waveTimer += Time.deltaTime;

        if (activeWave && (waveTimer >= setWaveTimer))
        {
            endWave();
        }

        //Cory Timer HUD stuff down here
        if (activeWave)
        {
            float amount = (setWaveTimer - waveTimer) / setWaveTimer;
            if (amount < 0)
            {
                amount = 0;
            }
            timerImage.fillAmount = amount;
        }

    }

    void startWave()
    {
        // Beginning of New Wave
        waveCount++;
        HUD_text_script.updateWaveCount();

        activeWave = true;
        foreach (EnemySpawnRange child in children)
        {
            child.UnpauseSpawners();
            child.SpawnSpawners(numToSpawn);
        }
        waveTimer = 0.0f;
        activeWave = true;
        waveStartPromptText.SetActive(false);
    }


    void endWave()
    {
        foreach (EnemySpawnRange child in children)
        {
            child.PauseSpawners();
        }
        activeWave = false;
        waveStartPromptText.SetActive(true);
    }

    public void startWaveInput()
    {
        if (!activeWave)
        {
            startWave();
        }
    }
}
