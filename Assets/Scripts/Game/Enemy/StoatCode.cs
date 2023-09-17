using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Pathfinding;

public class StoatCode : MonoBehaviour
{
    public Transform Player;
    public Transform RoamPos;

    public float StoatRoam = 0.5f;
    public float StoatChase = 0.75f;
    public float StoatSprint = 0.95f;

    public string StoatState; //idle, chase, pounce
    public float AttackPauseTime;

    public AIPath StoatPathfinding;
    public AIDestinationSetter StoatDestination;

    private void Awake()
    {
        StoatState = "idle";
        RoamPos.position = transform.position;
    }

    private void Update()
    {
        
        if (StoatPathfinding.desiredVelocity.x == 0 && StoatPathfinding.desiredVelocity.y == 0)
        {
            float randomX = Random.Range(-2, 2);
            float randomY = Random.Range(-2, 2);
            RoamPos.position = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);
        }

        //sets the position that the stoat will move to
        ///if the player is inside the trigger area, the stoat will move to the player
        ///otherwise the stoat will move to a roaming position
        if (StoatState == "chase")
        {
            StoatDestination.target = Player;
        }
        else if (StoatState == "idle")
        {
            StoatDestination.target = RoamPos;
            StoatPathfinding.maxSpeed = 0.35f;
        }
        else
        {
            Debug.LogError("Invalid StoatState");
        }

        if (StoatPathfinding.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerobject)
    {
        if (triggerobject.name == "Player")
        {
            StoatState = "chase";
            StoatPathfinding.maxSpeed = 0.8f;
        }
    }

    public void OnTriggerExit2D(Collider2D triggerobject)
    {
        if (triggerobject.name == "Player")
        {
            StoatState = "idle";
            StoatPathfinding.maxSpeed = 0.35f;
            RoamPos.position = transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            HeartSystemManager.health -= 1;
            StartCoroutine(AttackPause());
        }
    }

    private IEnumerator AttackPause()
    {
        StoatState = "idle";
        yield return new WaitForSecondsRealtime(AttackPauseTime);
        StoatState = "chase";
    }
}
