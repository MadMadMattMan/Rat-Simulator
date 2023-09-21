using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int[] inventory = new int[2];
    public int[] inventoryDebug = new int[2];

    public static Image[] inventoryItemUI = new Image[2];
    public Image[] inventoryItemUISetter = new Image[2];

    public static TextMeshProUGUI[] inventoryText = new TextMeshProUGUI[2];
    public TextMeshProUGUI[] inventoryTextSetter = new TextMeshProUGUI[2];

    public static Sprite[] inventoryItemSource = new Sprite[0];
    public Sprite[] inventoryItemSourceSetter = new Sprite[6];

    private void Awake()
    {
        //Inventory Number Code
        ///0 = null
        ///1 = food item
        ///2 = shiny things        

        for (int i = 0; i < inventoryItemUISetter.Count(); i++)
        {
            inventoryItemUI.Append(inventoryItemUISetter[i]);
        }

        for (int i = 0; i < inventoryItemSourceSetter.Count(); i++)
        {
            inventoryItemSource.Append(inventoryItemSourceSetter[i]);
        }

        for (int i = 0; i < inventoryTextSetter.Count(); i++)
        {
            inventoryText.Append(inventoryTextSetter[i]);
        }

        for (int i = 0; i < inventoryItemSourceSetter.Count(); i++)
        {
            inventoryItemSource.Append(inventoryItemSourceSetter[i]);
        }
        inventoryItemSource = inventoryItemSourceSetter;

        Debug.Log(inventoryItemSource[0]);
        Debug.Log(inventoryItemSource[1]);


        //Reset all inventory to empty, or no items collected at start of game
        for (int i = 0; i < 3; i++)
        {
            inventory[i] = 0;
            inventoryItemUI[i].sprite = inventoryItemSource[0];
            inventoryText[i].text = "Empty";
        }
    }

    private void Update()
    {
        //Matches the debugger array to the code array fir debugging purposes
        for (int i = 0; i < inventory.Count(); i++)
        {
            inventoryDebug[i] = inventory[i];
        }
    }

    public static void AddItem(int itemAdded)
    {
        if (inventory[0] == 0)
        {
            inventory[0] = itemAdded;
            if (itemAdded == 1)
            {
                int randomInt = Random.Range(2, 5);
                inventoryItemUI[0].sprite = inventoryItemSource[randomInt]; ;
                inventoryText[0].text = randomInt.ToString();

            }
            else
            {
                inventoryItemUI[0].sprite = inventoryItemSource[1];
            }
            
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
