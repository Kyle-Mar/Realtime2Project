using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ConsoleMenu : Menu
{
    // Start is called before the first frame update
    public PlayerInventory playerInventory;
    public Slot[] slots;
    public int rerollCost = 15;
    public TrapItem[] availableShopItems = new TrapItem[3];
    public AudioClip GravityFlipSoundEffect;
    System.Random rnd = new System.Random();

    void Start()
    {
        slots = this.menuObject.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipGravity()
    {
        gameObject.GetComponent<SFXPlayer>().PlaySFX(GravityFlipSoundEffect);
        CenterConsole.FlipGravity();
        MenuManager.CloseMenu(this);
    }

    public void RerollTraps() 
    {
        if(PlayerInventory.numCoins >= 15)
        {
            PlayerInventory.numCoins -= 15;
        }
        else
        {
            return;
        }
        NewItemsForSlots();

    }

    public override void OnOpen()
    {
        NewItemsForSlots();

    }

    private void NewItemsForSlots() 
    {
        foreach (Slot slot in slots)
        {
            TrapItem newTrap = selectNewTrap();
            slot.UpdateSlot(newTrap.image, newTrap.itemName, newTrap.cost);
        }
    }

    private TrapItem selectNewTrap() 
    {
        int randIndex = rnd.Next(0, availableShopItems.Length);
        return availableShopItems[randIndex];
    }

    public void PurchaseItem(Slot slot)
    {
        if (!slot.available)
        {
            return;
        }

        var trapItem = availableShopItems.Where(x => x.itemName == slot.text.text).FirstOrDefault();
        if (PlayerInventory.numCoins >= trapItem.cost)
        {
            if (playerInventory.AddItem(trapItem)) {
                slot.available = false;
                PlayerInventory.numCoins -= trapItem.cost;
            }
        } 
    }
}
