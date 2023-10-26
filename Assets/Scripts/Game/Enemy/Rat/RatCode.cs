using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //Imported asset that has the scripts for pathfinding

public class RatCode : MonoBehaviour
{

    public Transform Player;
    public Transform Target;
    public Transform Attack;

    public Animator Animator;
    public Transform RatTransform;

    public static bool AttackState = false;

    public AIPath RatPathfinding; //Imported from A*
    public AIDestinationSetter RatDestination; //Imported from A*

    private void Awake()
    {
        //Sets variables on cloneing
        Player = GameObject.Find("Player").transform;
        Target = GameObject.Find("Rat Target").transform;
        Attack = GameObject.Find("Rat Attack").transform;

        //Resets bool
        AttackState = false;

        //Checks if player is close to rat on spawn and if so delete the rat
        Vector3 DistanceToPlayer = transform.position - Player.position;

        if (DistanceToPlayer.magnitude < 2.5f)
        {
            RatSpawnCode.RatClone = null;
            Destroy(gameObject);
        }
        else //else begin pathfinding to hideout hole
        {
            RatDestination.target = Attack;
            RatPathfinding.maxSpeed = 1;
        }
    }

    private void Update()
    {
        //Creates vector 3s to track the distances between the rat and target points
        Vector3 DistanceToPlayer = transform.position - Player.position;
        Vector3 DistanceToTarget = transform.position - Target.position;
        Vector3 DistanceToAttack = transform.position - Attack.position;

        
        //If player gets to close to rat - run away
        if (DistanceToPlayer.magnitude < 1.25f)
        {
            RatDestination.target = Target;
            RatPathfinding.maxSpeed = 1.55f;
            AttackState = false;
            gameObject.GetComponent<AudioSource>().Stop();
        }

        if (DistanceToTarget.magnitude < 0.15f)
        {
            RatSpawnCode.RatClone = null;
            Destroy(gameObject);
        }

        if (DistanceToAttack.magnitude < 0.10f && !AttackState)
        {
            IsAttacking();
        }
        if (GameOverviewer.GameOver || GameOverviewer.GameOver)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    public void IsAttacking()
    {
        AttackState = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
