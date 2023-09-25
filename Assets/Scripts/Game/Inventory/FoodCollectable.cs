using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D triggerer)
    {
        if (triggerer.gameObject.name == "Player")
        {
            if (Inventory.inventory[0] == 0 || Inventory.inventory[1] == 0)
            {
                Inventory.AddItem(1);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Inventory Full");
            }
        }
    }
}
