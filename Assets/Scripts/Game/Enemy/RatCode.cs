using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatCode : MonoBehaviour
{
    public Transform Player;

    public Vector3 DistanceToPlayer;

    public static bool AttackState = true;


    private void Update()
    {
        DistanceToPlayer = transform.position - Player.position;
        
    }
}
