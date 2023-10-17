using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //Imported asset that has the scripts for pathfinding

public class RatCode : MonoBehaviour
{
    public Transform Player;
    public Transform Target;
    public Transform Attack;

    public static bool AttackState = true;

    public AIPath RatPathfinding; //Imported from A*
    public AIDestinationSetter RatDestination; //Imported from A*

    private void Start()
    {
        Vector3 DistanceToPlayer = transform.position - Player.position;
        if (DistanceToPlayer.magnitude < 2.5f)
        {
            Destroy(gameObject);
        }
        else
        {
            RatDestination.target = Attack;
        }
    }

    private void Update()
    {
        //Creates vector 3s to track the distances between the rat and target points
        Vector3 DistanceToPlayer = transform.position - Player.position;
        Vector3 DistanceToTarget = transform.position - Target.position;
        Vector3 DistanceToAttack = transform.position - Attack.position;

        
        //If player gets to close to rat - run away
        if (DistanceToPlayer.magnitude < 1)
        {
            RatDestination.target = Target;
        }
    }


}
