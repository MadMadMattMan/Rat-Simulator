using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawnCode : MonoBehaviour
{
    public GameObject EvilRat;
    public static GameObject EvilRatPrefab;

    public int TestTime;

    public bool Spawning;

    public static GameObject RatClone;

    private void Awake()
    {
        StopAllCoroutines();
        RatCode.AttackState = false;
        EvilRatPrefab = EvilRat;
        int WaitTime = Random.Range(20, 50);
        //int WaitTime = TestTime;
        //Debug.Log("Start Iniciated");
        StartCoroutine(RatSpawnDelay(WaitTime));
    }

    //Delays the rats spawn for 'Time' amount of time and then spawns one
    public IEnumerator RatSpawnDelay(int Time)
    {
        Spawning = true;
        //Debug.Log("SpawnDelay Iniciated");
        yield return new WaitForSeconds(Time);
        RatClone = Instantiate(EvilRatPrefab);
        //Debug.Log("Rat Spawned");
        Spawning = false;
    }

    private void Update()
    {

        if (RatClone == null && !Spawning)
        {
            StopAllCoroutines();
            StartCoroutine(RatSpawnDelay(Random.Range(60, 100)));
        }
    }
}
