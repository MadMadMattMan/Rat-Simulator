using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoatCode : MonoBehaviour
{
    public Transform Player;

    public Vector3 DistanceToPlayer;


    private void Update()
    {
        DistanceToPlayer = transform.position - Player.position;
    }
}
