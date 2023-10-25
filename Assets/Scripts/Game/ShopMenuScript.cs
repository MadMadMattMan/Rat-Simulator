using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class ShopMenuScript : MonoBehaviour
{
    public GameObject shopMenu;
    public static GameObject shopMenuStatic;

    //item stock setter
    public static int FoodStock;
    public static int LevelStock;

    public TextMeshProUGUI FoodNumber;
    public static TextMeshProUGUI FoodNumberStatic;
    public TextMeshProUGUI LevelNumber;
    public static TextMeshProUGUI LevelNumberStatic;

    //button text setting
    public TextMeshProUGUI Slot1ButtonText;
    public static TextMeshProUGUI Slot1ButtonTextStatic;
    public TextMeshProUGUI Slot2ButtonText;
    public static TextMeshProUGUI Slot2ButtonTextStatic;

    //Sets up items for the game
    private void Awake()
    {
        shopMenuStatic = shopMenu;
        shopMenuStatic.SetActive(false);

        FoodStock = 8;
        FoodNumberStatic = FoodNumber;
        FoodNumberStatic.text = FoodStock.ToString();

        LevelStock = 2;
        LevelNumberStatic = LevelNumber;
        LevelNumberStatic.text = LevelStock.ToString();

        Slot1ButtonTextStatic = Slot1ButtonText;
        Slot2ButtonTextStatic = Slot2ButtonText;
    }

    //Code that toggles shop opening, targetstate sting programmable to force open or force close shop
    public static void OpenCloseShop(string targetState)
    {
        //if specifically stated to close menu, close it. else toggle menu
        if (targetState == "close")
        {
            shopMenuStatic.SetActive(false);
        }

        //Open shop if shop closed and vice versa
        else if (!shopMenuStatic.activeSelf)
        {
            shopMenuStatic.SetActive(true);
        }
        else if (shopMenuStatic.activeSelf)
        {
            shopMenuStatic.SetActive(false);
        }
    }

    //Button code with int set in button editor for what slot has been clicked
    public static void PurchaseItem(int Item)
    {
        //If item is one, food item, and stock not empty, buy it by replacing shiny thing with the item
        if (Item == 1 && FoodStock > 0 && Inventory.inventory.Contains(2))
        {
            FoodStock--;
            FoodNumberStatic.text = FoodStock.ToString();
            for (int i = 0; i < 2; i++)
            {
                if (Inventory.inventory[i] == 2)
                {
                    Inventory.RemoveItem(i);
                    Inventory.AddItem(1);
                    i = 10;
                }
            }
        }
        //Same as above for item 2
        else if (Item == 2 && LevelStock > 0 && Inventory.inventory.Contains(2))
        {
            LevelStock--;
            LevelNumberStatic.text = LevelStock.ToString();
            for (int i = 0; i < 2; i++)
            {
                if (Inventory.inventory[i] == 2)
                {
                    Inventory.RemoveItem(i);
                    Inventory.AddItem(3);
                    i = 10;
                }
            }
        }
        //Informs the player that item is out of stock
        else
        {
            ToolTips.StartQuickMessage("Item out of stock");
        }

        //sets visuals for out of stock for both items
        if (FoodStock == 0)
        {
            FoodNumberStatic.text = "0";
            FoodNumberStatic.color = Color.red;
            Slot1ButtonTextStatic.text = "out of stock";
            Slot1ButtonTextStatic.color = Color.red;
        }
        if (LevelStock == 0)
        {
            LevelNumberStatic.text = "0";
            LevelNumberStatic.color = Color.red;
            Slot2ButtonTextStatic.text = "out of stock";
            Slot2ButtonTextStatic.color = Color.red;
        }
    }
}
