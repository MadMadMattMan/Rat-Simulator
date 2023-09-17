using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class StoatCode : MonoBehaviour
{
    public Transform Player;

    public float StoatRoam = 0.5f;
    public float StoatChase = 0.75f;
    public float StoatSprint = 0.95f;

    public Vector3 DistanceToPlayer;

    public string StoatState; //idle, chase, pounce
    public float AttackPauseTime;

    private void Update()
    {
        DistanceToPlayer = transform.position - Player.position;
        if (StoatState == "chase")
        {
            transform.position -= DistanceToPlayer.normalized * Time.deltaTime * StoatChase;
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerobject)
    {
        if (triggerobject.name == "Player")
        {
            StoatState = "chase";
        }
    }

    public void OnTriggerExit2D(Collider2D triggerobject)
    {
        if (triggerobject.name == "Player")
        {
            StoatState = "idle";
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
