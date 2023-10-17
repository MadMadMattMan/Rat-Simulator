using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //Imported asset that has the scripts for pathfinding

public class RatCode : MonoBehaviour
{
    public Transform Player;
    public Transform Target;
    public Transform Attack;

    public Sprite AttackSprite;

    public Animator Animator;
    public Transform RatTransform;
    public SpriteRenderer Renderer;

    public static bool AttackState = true;

    public AIPath RatPathfinding; //Imported from A*
    public AIDestinationSetter RatDestination; //Imported from A*

    private void Start()
    {
        AttackState = false;

        Vector3 DistanceToPlayer = transform.position - Player.position;

        if (DistanceToPlayer.magnitude < 2.5f)
        {
            Destroy(gameObject);
        }
        else
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
        if (DistanceToPlayer.magnitude < 1)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            RatDestination.target = Target;
            RatPathfinding.maxSpeed = 1.55f;
        }

        if (DistanceToTarget.magnitude < 0.15f)
        {
            Destroy(gameObject);
        }

        if (DistanceToAttack.magnitude < 0.05f)
        {
            IsAttacking();
        }
    }

    IEnumerator IsAttacking()
    {
        Animator.SetBool("Run", false);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(true);
        RatTransform.position = Attack.position;
        AttackState = true;
        Renderer.sprite = AttackSprite;
        yield return null;
    }
}
