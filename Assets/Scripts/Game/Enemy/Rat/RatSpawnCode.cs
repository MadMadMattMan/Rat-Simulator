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
        RatSpawnDelay(WaitTime);
    }

    public static IEnumerator RatSpawnDelay(int Time)
    {
        yield return new WaitForSeconds(Time);
        Instantiate(EvilRatPrefab);
    }
}
