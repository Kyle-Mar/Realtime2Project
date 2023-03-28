using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInventory : MonoBehaviour
{
    public static float numCoins = 0;
    public TMP_Text coinsText;
    List<InventorySlot> inventory = new List<InventorySlot>();
    const MAX_ITEMS_PER_TYPE = 5;
    const MAX_ITEMS = 3;

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

    public void AddItem(TrapItem itemToAdd)
    {
        if(inventory.Count + 1 > MAX_ITEMS)
        {
            return;
        }

        foreach(InventorySlot iSlot in inventory)
        {
            if(iSlot.item == itemToAdd)
            {
                if(iSlot < MAX_ITEMS_PER_TYPE + 1)
                {
                    iSlot.count++;
                }
            }
            else
            {
                InventorySlot newSlot = new();
                newSlot.item = itemToAdd;
                newSlot.count = 1;
            }
        }
    }

    public void RemoveItem(TrapItem itemToRemove)
    {
        foreach(InventorySlot iSlot in inventory)
        {
            if(iSlot.item == itemToRemove)
            {
                if(iSlot.count - 1 <= 0)
                {
                    inventory.Remove(iSlot);1`
                }
                else
                {
                    iSlot.count--;
                }
            }
        }
    }
}

public struct InventorySlot
{
    TrapItem item;
    int count;
}
