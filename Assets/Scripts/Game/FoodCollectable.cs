using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectable : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D triggerer)
    {
        if (triggerer.gameObject.name == "Player")
        Inventory.AddItem(1);
        Destroy(this);
    }

}
