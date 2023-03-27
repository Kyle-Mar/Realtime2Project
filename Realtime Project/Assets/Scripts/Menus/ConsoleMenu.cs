using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConsoleMenu : Menu
{
    // Start is called before the first frame update
    public Slot[] slots;
    public TrapShopItem[] availableShopItems = new TrapShopItem[3];
    System.Random rnd = new System.Random();

    void Start()
    {
        slots = this.menuObject.GetComponentsInChildren<Slot>();
        RerollTraps();
        MenuManager.CloseMenu(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipGravity()
    {
        CenterConsole.FlipGravity();
        MenuManager.CloseMenu(this);
    }

    public void RerollTraps() 
    {
        foreach (Slot slot in slots)
        {
            TrapShopItem newTrap = selectNewTrap();
            slot.UpdateSlot(newTrap.image, newTrap.itemName);
        }
    }

    private TrapShopItem selectNewTrap() 
    {
        int randIndex = rnd.Next(0, availableShopItems.Length);
        return availableShopItems[randIndex];
    }
}
