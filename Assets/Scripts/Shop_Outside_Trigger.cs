using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Outside_Trigger : MonoBehaviour
{
    public Transform IKEASPAWN;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<Transform>().position = IKEASPAWN.position;
        }       
    }
}
