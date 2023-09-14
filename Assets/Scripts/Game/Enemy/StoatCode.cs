using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoatCode : MonoBehaviour
{
    public Transform Player;

    public float StoatRoam = 0.5f;
    public float StoatChase = 0.75f;
    public float StoatSprint = 0.95f;

    public float StoatSpeed;

    public Vector3 DistanceToPlayer;

    public string StoatState;

    public Button DamageButton;

    private void Update()
    {
        DistanceToPlayer = transform.position - Player.position;
    }

    private void OnTriggerStay2D(Collider2D triggerobject)
    {
        if (triggerobject.name == "Player")
        {
            transform.position -= DistanceToPlayer.normalized * Time.deltaTime * StoatSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
