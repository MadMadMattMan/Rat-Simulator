using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    ControllerInputSystem ControllerSupport;
    public static GameObject TriggerInside = null;

    private void Awake()
    {
        ControllerSupport = new ControllerInputSystem();
        ControllerSupport.Controller.Enable();

        ControllerSupport.Controller.Interact.performed += ctx => Interact();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
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
            //
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

}
