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

    private void Awake()
    {
        ControllerSupport = new ControllerInputSystem();
        ControllerSupport.Controller.Enable();

        ControllerSupport.Controller.Interact.performed += ctx => Interact();
        ControllerSupport.Controller.ItemSelectionLeft.performed += ctx => ItemSelector("Left");
        ControllerSupport.Controller.ItemSelectionRight.performed += ctx => ItemSelector("Right");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerInside = collision.gameObject;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        TriggerInside = null;

        if (collision.gameObject.name == "Shop Zone")
            ShopMenuScript.OpenCloseShop("close");
            
    }

    public static void Interact()
    {
        if (TriggerInside == null)
        {
            Debug.Log("Nothing to interact with");
        }

        if (TriggerInside.name == "Shop Zone")
        {
            ShopMenuScript.OpenCloseShop(null);
        }

        if (TriggerInside.name == "Egg Interact Zone")
        {
            if (SelectedItem == 1)
            {
                if (Inventory.inventory[0] == 0)
                {
                    Debug.Log("Item1 Slot Empty");
                }
                else if (Inventory.inventory[0] == 1)
                {
                    EggHealthSystem.HealerStatic = 25;
                    Inventory.RemoveItem(0);
                }
                else if (Inventory.inventory[0] == 2)
                {

                }
                else if (Inventory.inventory[0] == 3)
                {
                    EggHealthSystem.eggStageInt++;
                    EggHealthSystem.eggStageTextStatic.text = "Stage " + EggHealthSystem.eggStageInt;
                }
            }
            else if (SelectedItem == 2)
            {
                if (Inventory.inventory[1] == 0)
                {
                    Debug.Log("Item2 Slot Empty");
                }
                else
                {
                    Debug.Log("Used Item2 On egg");
                }
            }
        }

        if (TriggerInside.name == "Morepork Interact Zone")
        {
            //
        }

        if (TriggerInside.name == "Penguin Interact Zone")
        {
            //
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

}