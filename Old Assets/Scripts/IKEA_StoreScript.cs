using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKEA_StoreScript : MonoBehaviour
{
    public Collider2D StoreTP;
    public Transform StoreTPMainMap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.gameObject.GetComponent<Transform>().position = StoreTPMainMap.position;
        }
    }
}