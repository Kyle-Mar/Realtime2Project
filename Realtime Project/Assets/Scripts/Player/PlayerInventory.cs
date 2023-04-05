using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
public class PlayerInventory : MonoBehaviour
{
    const int MAX_ITEMS_PER_TYPE = 5;
    const int MAX_ITEMS = 3;

    [SerializeField]
    private static float startCoins = 9999;
    public static float numCoins;
    public TMP_Text coinsText;

    List<InventorySlot> inventory = new List<InventorySlot>();
    public TrapItem testItem;

    public GameObject canvasObject;
    public GameObject inventoryHudIcon;
    List<GameObject> inventoryIcons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        numCoins = startCoins;
        coinsText = GameObject.Find("Coins Text").GetComponent<TMP_Text>();
        coinsText.text = "Coins: " + numCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + numCoins.ToString();
    }

    public static void ResetCoins()
    {
        numCoins = startCoins;
    }

    public bool AddItem(TrapItem itemToAdd)
    {
        if(inventory.Count> MAX_ITEMS)
        {
            return false;
        }
        int index = 0;

        foreach(InventorySlot iSlot in inventory.ToArray())
        {
            if(iSlot.item == itemToAdd)
            {
                if(iSlot.count < MAX_ITEMS_PER_TYPE)
                {
                    inventory[index].count++;
                    DrawInventory();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            index++;
        }
        InventorySlot newSlot = new();
        newSlot.item = itemToAdd;
        newSlot.count = 1;
        inventory.Add(newSlot);
        DrawInventory();
        return true;
    }

    public bool RemoveItem(TrapItem itemToRemove)
    {
        int index = 0;
        foreach(InventorySlot iSlot in inventory)
        {
            if(iSlot.item == itemToRemove)
            {
                if(iSlot.count - 1 <= 0)
                {
                    inventory.Remove(iSlot);
                    DrawInventory();
                    return true;
                }
                else
                {
                    inventory[index].count--;
                    DrawInventory();
                    return true;
                }
            }
            index++;
        }
        return false;
    }

    public RemoveItemResult RemoveItem(int idx)
    {
        if(idx < 0)
        {
            return new RemoveItemResult(null, false);
        }
        if(idx > inventory.Count-1)
        {
            return new RemoveItemResult(null, false);
        }
        InventorySlot slot = inventory[idx];
        if(slot.count -1 <= 0)
        {
            inventory.RemoveAt(idx);
            DrawInventory();
            return new RemoveItemResult(slot.item, true);
        }
        else
        {
            inventory[idx].count--;
            DrawInventory();
            return new RemoveItemResult(slot.item, true);
        }
    }

    public void DrawInventory()
    {
        for(int i = 0; i < inventoryIcons.Count; i++)
        {
            Destroy(inventoryIcons[i]);
        }

        RectTransform rect = canvasObject.GetComponent<RectTransform>();

        float height = rect.sizeDelta.y * rect.localScale.y;
        float width = rect.sizeDelta.x * rect.localScale.x;


        Vector3 startPos = new Vector3(width/20, height - height /10, 0f);
        Vector3 iconPos = startPos;
        int index = 1;
        foreach(InventorySlot slot in inventory)
        {
            GameObject iconObject = Instantiate(inventoryHudIcon, iconPos, Quaternion.identity, canvasObject.transform);
            Debug.Log(iconObject.transform.position);
            Image image = iconObject.GetComponent<Image>();
            TMP_Text text = iconObject.GetComponentInChildren<TMP_Text>();

            image.sprite = slot.item.image;
            text.text = slot.item.itemName + ": " + slot.count;
            iconPos.y = startPos.y - (height / 5) * index;

            index++;

            inventoryIcons.Add(iconObject);

        }


    }
}

public class InventorySlot
{
    public TrapItem item;
    public int count;
}

public class RemoveItemResult
{
    public TrapItem Item;
    public bool Success;

    public RemoveItemResult(TrapItem item, bool success)
    {
        Item = item;
        Success = success;
    }

}