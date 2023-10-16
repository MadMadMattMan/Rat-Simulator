using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCollectable : MonoBehaviour
{
    private ControllerInputSystem ControllerSupport;
    private bool Pickup;

    private void Start()
    {
        Pickup = false;

        ControllerSupport = new ControllerInputSystem();
        ControllerSupport.Controller.Enable();

        ControllerSupport.Controller.Pickup.performed += ctx => Pickup = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pickup = true;
        }
    }

    private void OnTriggerStay2D(Collider2D triggerer)
    {
        if (triggerer.gameObject.name == "Player" && Pickup == true)
        {
            Pickup = false;
            if (Inventory.inventory[0] == 0 || Inventory.inventory[1] == 0)
            {
                Inventory.AddItem(3);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Inventory Full");
            }
        }
    }
}
