using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectable : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Inventory.AddItem(1);
        Destroy(gameObject);
    }

}
