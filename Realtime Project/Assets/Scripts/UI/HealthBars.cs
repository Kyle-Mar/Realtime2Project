using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBars : MonoBehaviour
{

    IDamageable playerDmgInterface;
    IDamageable consoleDmgInterface;

    RectTransform playerHealthBar;
    RectTransform consoleHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerDmgInterface = GameObject.Find("Player").GetComponent<IDamageable>();
        consoleDmgInterface = GameObject.Find("Center Console").GetComponent<IDamageable>();

        playerHealthBar = GameObject.Find("Player Health Bar").GetComponent<RectTransform>();
        consoleHealthBar = GameObject.Find("Console Health Bar").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (playerDmgInterface.health / playerDmgInterface.MAX_HEALTH) * 100);
        consoleHealthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (consoleDmgInterface.health / consoleDmgInterface.MAX_HEALTH) * 100);
        //playerHealthBar.rect.Set(playerHealthBar.rect.x, playerHealthBar.rect.y, playerDmgInterface.health, playerHealthBar.rect.height);
        //consoleHealthBar.rect.Set(playerHealthBar.rect.x, playerHealthBar.rect.y, consoleDmgInterface.health, playerHealthBar.rect.height);
    }
}
