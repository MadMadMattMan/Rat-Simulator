using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout_Outside_Trigger : MonoBehaviour
{
    public Transform HideoutSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<Transform>().position = HideoutSpawn.position;
        }       
    }
}
