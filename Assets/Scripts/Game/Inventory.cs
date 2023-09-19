using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int[] inventory = new int[1];
    public int[] inventoryDebug = new int[1];

    public Image[] inventoryItemUI = new Image[1];
    public Image[] inventoryItemSource = new Image[1];

    private void Awake()
    {
        //Inventory Number Code
        ///0 = null
        ///1 = food item
        ///2 = shiny things

        

        //Reset inventory at start of game
        foreach (int i in inventory)
        {
            inventory[i] = 0;
        }
    }

    private void Update()
    {
        //Matches the debugger array to the code array fir debugging purposes
        foreach (int i in inventory)
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
