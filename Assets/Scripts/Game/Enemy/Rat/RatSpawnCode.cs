using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawnCode : MonoBehaviour
{
    public GameObject EvilRat;
    public static GameObject EvilRatPrefab;

    public int TestTime;

    private void Start()
    {
        EvilRatPrefab = EvilRat;
        //int WaitTime = Random.Range(20, 50);
        int WaitTime = TestTime;
        Debug.Log("Start Iniciated");
        StartCoroutine(RatSpawnDelay(WaitTime));
    }

    //Delays the rats spawn for 'Time' amount of time and then spawns one
    public IEnumerator RatSpawnDelay(int Time)
    {
        Debug.Log("SpawnDelay Iniciated");
        yield return new WaitForSeconds(Time);
        Instantiate(EvilRatPrefab);
        Debug.Log("Rat Spawned");
    }

    private void Update()
    {
        //Search the scene to see if there is a rat spawned and if ratdelaycoroutine is not enabled
        //Start RatSpawnDelay
    }
}
