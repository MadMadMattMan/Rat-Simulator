using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int[] inventory = new int[2];
    public int[] inventoryDebug = new int[2];

    public Image[] inventoryItemUI = new Image[2];

    public TextMeshProUGUI[] inventoryText = new TextMeshProUGUI[2];

    public Sprite[] inventoryItemSource = new Sprite[7];

    private void Awake()
    {
        //Inventory Number Code
        ///0 = null
        ///1 = food item
        ///2 = shiny things        

        //Reset all inventory to empty, or no items collected at start of game
        for (int i = 0; i < 2; i++)
        {
            inventory[i] = 0;
            inventoryItemUI[i].sprite = inventoryItemSource[0];
            inventoryText[i].text = "Empty";
        }
    }

    private void Update()
    {
        //Matches the debugger array to the code array fir debugging purposes
        for (int i = 0; i < 2; i++)
        {
            inventoryDebug[i] = inventory[i];
        }
    }

    public static void AddItem(int itemAdded)
    {
        if (inventory[0] == 0)
        {
            inventory[0] = itemAdded;
        }
        else if (inventory[1] == 0)
        {
            inventory[1] = itemAdded;
        }
        else
        {
            Debug.LogError("Failed to add " + itemAdded + " to inventory");
        }
    }

    public static void RemoveItem(int itemRemoved)
    {
        if (inventory[0] == itemRemoved)
        {
            inventory[0] = 0;
        }
        else if (inventory[1] == itemRemoved)
        {
            inventory[1] = 0;
        }
        else
        {
            Debug.LogError("Failed to remove " + itemRemoved + " from inventory");
        }
    }

}
