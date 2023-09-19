using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int[] inventory = new int[1];
    public int[] inventorydebug = new int[1];

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
            inventorydebug[i] = inventory[i];
        }
    }

    public static void AddItem(int ItemAdded)
    {
        if (inventory[0] == 0)
        {
            inventory[0] = ItemAdded;
        }
        else if (inventory[1] == 0)
        {
            inventory[1] = ItemAdded;
        }
        else
        {
            Debug.LogError("Failed to add " + ItemAdded + " to inventory");
        }
    }

    public static void RemoveItem(int ItemRemoved)
    {
        if (inventory[0] == ItemRemoved)
        {
            inventory[0] = 0;
        }
        else if (inventory[1] == ItemRemoved)
        {
            inventory[1] = 0;
        }
        else
        {
            Debug.LogError("Failed to remove " + ItemRemoved + " from inventory");
        }
    }

}
