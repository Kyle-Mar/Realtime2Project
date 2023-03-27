using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInventory : MonoBehaviour
{
    public static float numCoins = 0;
    public TMP_Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = "Coins: " + numCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + numCoins.ToString();
    }
}
