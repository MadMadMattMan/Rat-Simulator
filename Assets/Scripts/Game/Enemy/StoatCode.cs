using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoatCode : MonoBehaviour
{
    public Transform Player;

    public float StoatRoam = 0.5f;
    public float StoatChase = 0.75f;
    public float StoatSprint = 0.95f;

    public float StoatSpeed;

    public Vector3 DistanceToPlayer;

    public string StoatState;


    private void Update()
    {
        DistanceToPlayer = transform.position - Player.position;
    }

    private void OnTriggerStay2D(Collider2D triggerobject)
    {
        if (triggerobject.name == "Player")
        {
            StoatState = "Active";
        }
    }

    private void OnTriggerExit2D(Collider2D triggerobject)
    {
        if (triggerobject.name == "Player")
        {
            StoatState = "Idle";
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(StoatStateMovement());
    }

    public IEnumerator StoatStateMovement()
    {
        while (StoatState == "Active")
        {
            transform.position -= DistanceToPlayer.normalized * Time.deltaTime * StoatSpeed;
        }

        return null;
    }
}
