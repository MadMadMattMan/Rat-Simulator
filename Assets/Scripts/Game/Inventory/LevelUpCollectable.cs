using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCollectable : MonoBehaviour
{
    private void Awake()
    {
        SpawnDealy();
    }

    IEnumerator SpawnDealy()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSecondsRealtime(2.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D triggerer)
    {
        if (triggerer.gameObject.name == "Player")
        {
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
