using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout_Script : MonoBehaviour
{
    public Transform HideoutTPMainMap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.gameObject.GetComponent<Transform>().position = HideoutTPMainMap.position;
        }
    }
}