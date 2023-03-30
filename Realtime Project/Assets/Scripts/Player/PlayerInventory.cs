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
    
    public static float numCoins = 0;
    public TMP_Text coinsText;

    List<InventorySlot> inventory = new List<InventorySlot>();
    public TrapItem testItem;

    public GameObject canvasObject;
    public GameObject inventoryHudIcon;
    List<GameObject> inventoryIcons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = "Coins: " + numCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)){
            DrawInventory();
            foreach (var item in inventory)
            {
                Debug.Log(item.count + item.item.name);
            }

        }
        coinsText.text = "Coins: " + numCoins.ToString();
    }

    public void AddItem(TrapItem itemToAdd)
    {
        if(inventory.Count> MAX_ITEMS)
        {
            return;
        }
        int index = 0;

        foreach(InventorySlot iSlot in inventory.ToArray())
        {
            if(iSlot.item == itemToAdd)
            {
                if(iSlot.count < MAX_ITEMS_PER_TYPE)
                {
                    inventory[index].count++;
                    return;
                }
                else
                {
                    return;
                }
            }
            index++;
        }
        InventorySlot newSlot = new();
        newSlot.item = itemToAdd;
        newSlot.count = 1;
        inventory.Add(newSlot);
    }

    public void RemoveItem(TrapItem itemToRemove)
    {
        int index = 0;
        foreach(InventorySlot iSlot in inventory)
        {
            if(iSlot.item == itemToRemove)
            {
                if(iSlot.count - 1 <= 0)
                {
                    inventory.Remove(iSlot);
                    return;
                }
                else
                {
                    inventory[index].count--;
                    return;
                }
            }
            index++;
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
            text.text = slot.item.itemName;
            iconPos.y = startPos.y - (height / 10) * index;

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
