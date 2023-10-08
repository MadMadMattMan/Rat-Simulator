using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ShopMenuScript : MonoBehaviour
{
    public GameObject shopMenu;
    public static GameObject shopMenuStatic;

    private void Awake()
    {
        shopMenuStatic = shopMenu;
        shopMenuStatic.SetActive(false);
    }

    public static void OpenCloseShop(string targetState)
    {
        //if specifically stated to close menu, close it. else toggle menu
        if (targetState == "closed")
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

}
