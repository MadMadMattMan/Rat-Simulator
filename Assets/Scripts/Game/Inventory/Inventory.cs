using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int[] inventory = new int[0];
    public int[] inventoryDebug = new int[2];

    public static Image[] inventoryItemUI = new Image[0];
    public Image[] inventoryItemUISetter = new Image[2];

    public static TextMeshProUGUI[] inventoryText = new TextMeshProUGUI[0];
    public TextMeshProUGUI[] inventoryTextSetter = new TextMeshProUGUI[2];

    public static Sprite[] inventoryItemSource = new Sprite[0];
    public Sprite[] inventoryItemSourceSetter = new Sprite[6];

    private void Awake()
    {
        //Inventory Number Code
        ///0 = null
        ///1 = food item (Heals 25hp)
        ///2 = shiny things  (Used to by objects)
        ///3 = Level Up (Increases egg stage)

        inventory = inventoryDebug;
        inventoryItemUI = inventoryItemUISetter;
        inventoryText = inventoryTextSetter;
        inventoryItemSource = inventoryItemSourceSetter;


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
                //randomly assigns a food item from the seeds, bugs etc.
                int randomInt = Random.Range(2, 5);
                inventoryItemUI[0].sprite = inventoryItemSource[randomInt]; ;
                inventoryText[0].text = "Food";

            }
            else if (inventory[0] == 2)
            {
                //adds shiny things to inventory
                inventoryItemUI[0].sprite = inventoryItemSource[1];
                inventoryText[0].text = "Shiny Thing";
            }
            else if (inventory[0] == 3)
            {
                inventoryItemUI[0].sprite = inventoryItemSource[6];
                inventoryText[0].text = "Level Up";
            }
            else
                Debug.LogError("Invalid Item Collected Number");
            
        }
        else if (inventory[1] == 0)
        {
            inventory[1] = itemAdded;
            if (itemAdded == 1)
            {
                //randomly assigns a food item from the seeds, bugs etc.
                int randomInt = Random.Range(2, 5);
                inventoryItemUI[1].sprite = inventoryItemSource[randomInt]; ;
                inventoryText[1].text = "Food";

            }
            else if (inventory[1] == 2)
            {
                //adds shiny things to inventory
                inventoryItemUI[1].sprite = inventoryItemSource[1];
                inventoryText[1].text = "Shiny Thing";
            }
            else if (inventory[1] == 3)
            {
                inventoryItemUI[1].sprite = inventoryItemSource[6];
                inventoryText[1].text = "Level Up";
            }
            else
                Debug.LogError("Invalid Item Collected Number");
        }
        else
        {
            Debug.LogError("Failed to add " + itemAdded + " to inventory");
        }
    }

    public static void RemoveItem(int itemRemoved)
    {
        if (itemRemoved == 0)
        {
            inventory[0] = 0;
            inventoryItemUI[0].sprite = inventoryItemSource[0];
            inventoryText[0].text = "Empty";
        }
        else if (itemRemoved == 1)
        {
            inventory[1] = 0;
            inventoryItemUI[1].sprite = inventoryItemSource[0];
            inventoryText[1].text = "Empty";
        }
        else
        {
            Debug.LogError("Failed to remove " + itemRemoved + " from inventory");
        }
    }

}
