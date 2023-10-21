using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    ControllerInputSystem ControllerSupport;
    public static GameObject TriggerInside = null;

    public static int SelectedItem;
    public RectTransform Highlight;
    public RectTransform HighlightDefault;
    public RectTransform HighlightFlipped;

    public GameObject[] ItemSpawn = new GameObject[2];

    //Awake function sets up all teh variables and states the controller actions and assigns a void to it
    private void Awake()
    {
        ControllerSupport = new ControllerInputSystem();
        ControllerSupport.Controller.Enable();
        SelectedItem = 2;

        ControllerSupport.Controller.Interact.performed += ctx => Interact();
        ControllerSupport.Controller.ItemSelectionLeft.performed += ctx => ItemSelector("Left");
        ControllerSupport.Controller.ItemSelectionRight.performed += ctx => ItemSelector("Right");
        ControllerSupport.Controller.DropItem.performed += ctx => DropItem();

    }

    //Checks for user inputs and starts the designated void for keyboard and mouse
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            ItemSelector("Left");
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            ItemSelector("Right");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedItem = 1;
            UpdateVisuals();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedItem = 2;
            UpdateVisuals();
        }
    }

    //Assigns the Triggerinside variable to the triggers gameobject that the player is inside of
    public void OnTriggerStay2D(Collider2D collision)
    {
        TriggerInside = collision.gameObject;
    }

    //Resets Triggerinside when player leaves a trigger zone
    //Closes the shop menu when player leaves the shop
    public void OnTriggerExit2D(Collider2D collision)
    {
        TriggerInside = null;

        if (collision.gameObject.name == "Shop Zone")
            ShopMenuScript.OpenCloseShop("close");      
    }


    //All the interaction code
    public static void Interact()
    {
        //Player guidance if they try to interact with something uninteractable
        if (TriggerInside == null)
        {
            ToolTips.StartQuickMessage("Nothing to interact with");
        }
        //Opens the shop if player talks to KEA
        else if (TriggerInside.name == "Shop Zone")
        {
            ShopMenuScript.OpenCloseShop(null);
        }

        //Uses selected item in inventory to feed to egg, food heals, leveler upper ups the stage the player in on and shiny things can't be used so the tooltips are used to guide the player
        else if (TriggerInside.name == "Egg Interact Zone")
        {
            if (SelectedItem == 1)
            {
                if (Inventory.inventory[0] == 0)
                {
                    Debug.Log("Item1 Slot Empty");
                } //If inventory Empty
                else if (Inventory.inventory[0] == 1)
                {
                    EggHealthSystem.HealerStatic = 25;
                    Inventory.RemoveItem(0);
                } //If item is healer
                else if (Inventory.inventory[0] == 2)
                {
                    Debug.Log("Cannot Use item on Egg");
                    ToolTips.StartQuickMessage("Can't use item on eggs");
                }
                else if (Inventory.inventory[0] == 3)
                {
                    EggHealthSystem.eggStageInt++;
                    EggHealthSystem.eggStageTextStatic.text = "Stage " + EggHealthSystem.eggStageInt.ToString();
                    Inventory.RemoveItem(0);
                } //If item levels up egg
            }
            else if (SelectedItem == 2)
            {
                if (Inventory.inventory[1] == 0)
                {
                    Debug.Log("Item2 Slot Empty");
                }
                else
                {
                    if (Inventory.inventory[1] == 0)
                    {
                        Debug.Log("Item1 Slot Empty");
                    } //If inventory Empty
                    else if (Inventory.inventory[1] == 1)
                    {
                        EggHealthSystem.HealerStatic = 25;
                        Inventory.RemoveItem(1);
                    } //If item is healer
                    else if (Inventory.inventory[1] == 2)
                    {
                        Debug.Log("Cannot Use item on Egg");
                        ToolTips.StartQuickMessage("Can't use item on egg");
                    }
                    else if (Inventory.inventory[1] == 3)
                    {
                        EggHealthSystem.eggStageInt++;
                        EggHealthSystem.eggStageTextStatic.text = "Stage " + EggHealthSystem.eggStageInt;
                        Inventory.RemoveItem(1);
                    } //If item levels up egg
                }
            }
        }

        else if (TriggerInside.name == "Morepork Interact Zone")
        {
            //
        }

        //If the player has not recived an item, interact with the penguin and if the player has recived an item, don't and tell player that
        else if (TriggerInside.name == "Penguin Interact Zone")
        {
            //Debug.Log("Interacted With Penguin");
            if (!PenguinScript.GivenItem)
                PenguinScript.PenguinInteracted();
            else
                ToolTips.StartQuickMessage("Penguin doesn't want to talk right now");
        }
    }

    public static void NPCInteract(string type)
    {
        if (type == "Penguin")
        {
            if (SelectedItem == 1)
            {
                if (Inventory.inventory[0] == 0)
                {
                    Debug.Log("Item1 Slot Empty");
                } //If inventory Empty
                else if (Inventory.inventory[0] == 1)
                {
                    PenguinScript.GaveFood();
                    Inventory.RemoveItem(0);
                } //If item is healer
                else if (Inventory.inventory[0] == 2 | Inventory.inventory[0] == 3)
                {
                    Debug.Log("Cannot Use item on Egg");
                    ToolTips.StartQuickMessage("Penguin doesn't need this");
                }
            }
            else if (SelectedItem == 2)
            {
                if (Inventory.inventory[1] == 0)
                {
                    Debug.Log("Item1 Slot Empty");
                } //If inventory Empty
                else if (Inventory.inventory[1] == 1)
                {
                    PenguinScript.GaveFood();
                    Inventory.RemoveItem(1);
                } //If item is healer
                else if (Inventory.inventory[1] == 2 | Inventory.inventory[1] == 3)
                {
                    Debug.Log("Cannot Use item on Egg");
                    ToolTips.StartQuickMessage("Penguin doesn't need this");
                }
            }
        }

        if (type == "Morepork")
        {

        }
        
    }

    public void ItemSelector(string Direction)
    {
        if (Direction == "Left")
        {
            SelectedItem++;
            if (SelectedItem == 3)
            {
                SelectedItem = 1;
            }
            UpdateVisuals();
        }
        if (Direction == "Right")
        {
            SelectedItem--;
            if (SelectedItem == 0)
            {
                SelectedItem = 2;
            }
            UpdateVisuals();
        }
    }

    private void UpdateVisuals()
    {
        if (SelectedItem == 1)
            Highlight.position = HighlightFlipped.position;
        else if (SelectedItem == 2)
            Highlight.position = HighlightDefault.position;
    } 

    public void DropItem()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (Inventory.inventory[SelectedItem - 1] == i)
            {
                Instantiate(ItemSpawn[i - 1], gameObject.transform.position, gameObject.transform.rotation);
                Inventory.RemoveItem(SelectedItem - 1);
            }
        }
    }
}
