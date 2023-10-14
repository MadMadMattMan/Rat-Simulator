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

    public static int FoodStock;
    public static int LevelStock;

    public TextMeshProUGUI FoodNumber;
    public static TextMeshProUGUI FoodNumberStatic;
    public TextMeshProUGUI LevelNumber;
    public static TextMeshProUGUI LevelNumberStatic;

    private void Awake()
    {
        shopMenuStatic = shopMenu;
        shopMenuStatic.SetActive(false);
        FoodStock = 5;
        FoodNumberStatic = FoodNumber;
        LevelStock = 2;
        LevelNumberStatic = LevelNumber;
    }

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

    public static void PurchaseItem(int Item)
    {
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
        else
        {
            Debug.LogError("Invalid Item Purchased");
        }
    }

}
