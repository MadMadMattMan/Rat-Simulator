using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Pathfinding; //Imported asset that has the scripts for pathfinding

public class StoatCode : MonoBehaviour
{
    public Transform Player;
    public Transform RoamPos;

    public float StoatRoam = 0.25f;
    public float StoatChase = 0.75f;

    public string StoatState; //idle, chase, pounce
    public float AttackPauseTime; //time stoat pauses after an attack

    public AIPath StoatPathfinding; //Imported from A*
    public AIDestinationSetter StoatDestination; //Imported from A*

    public RaycastHit2D PlayerRay;
    public RaycastHit2D RoamRay;

    private void Awake()
    {
        StoatState = "idle";
        RoamPos.position = transform.position;
    }

    private void Update()
    {
        //PlayerRay = Physics2D.Raycast()
        //RoamRay = Physics2D.Raycast()

        //if the stoat stops moving (ie at roam pos) create a new random roam position
        if (StoatPathfinding.desiredVelocity.x == 0 && StoatPathfinding.desiredVelocity.y == 0)
        {
            float randomX = Random.Range(-2, 2); //Random float value used for random roam (x)
            float randomY = Random.Range(-2, 2); //Random float value used for random roam (y)
            RoamPos.position = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z); //Adds random roam vales to position to 
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
            StoatPathfinding.maxSpeed = StoatRoam;
        }
        else
        {
            Debug.LogError("Invalid StoatState"); //bugfixing error debugger
        }

        //Flip the stoat sprite if he is moving right otherwise keep normal scale.
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
        //if player enters the trigger zone, activate chase
        if (triggerobject.name == "Player")
        {
            StoatState = "chase";
            StoatPathfinding.maxSpeed = StoatChase;
        }
    }

    public void OnTriggerExit2D(Collider2D triggerobject)
    {
        //if player leaves the trigger zone, go back to roaming
        if (triggerobject.name == "Player")
        {
            StoatState = "idle";
            StoatPathfinding.maxSpeed = 0.35f;
            RoamPos.position = transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if player is attacked, remove a heart and roam for AttackPauseTime variable
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
