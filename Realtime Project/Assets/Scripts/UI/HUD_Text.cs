using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD_Text : MonoBehaviour
{
    // Start is called before the first frame update
    SpawnSystem spawnScript;
    TextMeshProUGUI waveText;
    private void Start()
    {
    }
    public void updateWaveCount()
    {
        spawnScript = GameObject.Find("SpawnRanges").GetComponent<SpawnSystem>();
        waveText = GameObject.Find("Wave Text").GetComponent<TextMeshProUGUI>();
        Debug.Log(waveText.text);
        Debug.Log(spawnScript.waveCount);
        waveText.text = "Wave " + spawnScript.waveCount;
    }
}
